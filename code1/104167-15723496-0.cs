    namespace OfficeOpenXml
    {
       using System;
       using System.Collections.Generic;
       using System.Text;
       using OfficeOpenXml.Style;
       using System.Data;
    /// <summary>
    /// This class provides easy access to used range objects such as
    /// UsedRows, UsedColumns, UsedCells, UsedRow, UsedColumn etc.
    /// Authored by Mukesh Adhvaryu
    /// </summary>
    public sealed class UsedRange : ExcelRange,IEnumerable<UsedRange>
    {
        #region local variables
        int elementIndex=-1, cursor=-1, position=-1;
        UsedRangeElement element, parentElement;
        public const long MaxCells =(long) ExcelPackage.MaxRows *  
    (long)ExcelPackage.MaxColumns;
        #endregion
        #region constructors
        /// <summary>
        /// this constructor is private because its accessibility outside can cause mess
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="element"></param>
        /// <param name="elementIndex"></param>
        /// <param name="cursor"></param>
        UsedRange(ExcelWorksheet sheet, UsedRangeElement element, int elementIndex, int cursor)
            : base(sheet)
        {
            this.element = element;
            switch (element)
            {
                case UsedRangeElement.Rows:
                case UsedRangeElement.Columns:
                case UsedRangeElement.Cells:
                    parentElement = UsedRangeElement.Range;
                    break;
                case UsedRangeElement.Row:
                    parentElement = UsedRangeElement.Rows;
                    break;
                case UsedRangeElement.Column:
                    parentElement = UsedRangeElement.Columns;
                    break;
                case UsedRangeElement.Cell:
                    parentElement = UsedRangeElement.Cells;
                    break;
                case UsedRangeElement.RowCell:
                    parentElement = UsedRangeElement.Row;
                    break;
                case UsedRangeElement.ColumnCell:
                    parentElement = UsedRangeElement.Column;
                    break;
                default:
                    parentElement = 0;
                    break;
            }
            this.elementIndex = elementIndex;
            this.cursor = cursor;
            SetRange();
        }
        /// <summary>
        /// this constructor is private because its accessibility outside can cause mess
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="element"></param>
        /// <param name="elementIndex"></param>
        UsedRange(ExcelWorksheet sheet, UsedRangeElement element, int elementIndex)
            : this(sheet, element, elementIndex, -1) { }
        /// <summary>
        /// this constructor is private because its accessibility outside can cause mess
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="element"></param>
        UsedRange(ExcelWorksheet sheet, UsedRangeElement element)
            : this(sheet, element, -1, -1) { }
        /// <summary>
        /// this constructor used only to create cellcollection range
        /// since cellindex can be very large long value considering rows * columns =no of cells in worksheet
        /// this constructor is private because its accessibility outside can cause mess
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="cellIndex"></param>
        UsedRange(ExcelWorksheet sheet, long cellIndex)
            : base(sheet)
        {
            this.element = UsedRangeElement.Cell;
            this.parentElement = UsedRangeElement.Cells;
            CellToAddress(cellIndex);
            SetRange();
        }
        #endregion
        #region indexers & properties
        /// <summary>
        /// Returns element at a given index 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public UsedRange this[int index]
        {
            get
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                switch (element)
                {
                    case UsedRangeElement.Rows:
                        ValidateRow(index);
                        return new UsedRange(_worksheet, UsedRangeElement.Row, index);
                    case UsedRangeElement.Columns:
                        ValidateCol(index);
                        return new UsedRange(_worksheet, UsedRangeElement.Column, index);
                    case UsedRangeElement.Cells:
                        ValidateCell(index);
                        return new UsedRange(_worksheet, index);
                    case UsedRangeElement.Row:
                        return new UsedRange(_worksheet, UsedRangeElement.RowCell, elementIndex, index);
                    case UsedRangeElement.Column:
                        return new UsedRange(_worksheet, UsedRangeElement.ColumnCell, elementIndex, index);
                    default:
                        return this;
                }
            }
        }
        /// <summary>
        /// Returns particular Cell at a given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public UsedRange this[long index]
        {
            get
            {
                ValidateCell(index);
                return new UsedRange(_worksheet, index);
            }
        }
        /// <summary>
        /// Returns count of elements in this collection
        /// </summary>
        public int Count
        {
            get
            {
                switch (element)
                {
                    case UsedRangeElement.Rows:
                    case UsedRangeElement.Column:
                        return _toRow - _fromRow + 1;
                    case UsedRangeElement.Columns:
                    case UsedRangeElement.Row:
                        return _toCol - _fromCol + 1;
                    case UsedRangeElement.Cells:
                    case UsedRangeElement.Range:
                        return (_toRow - _fromRow + 1) * (_toCol - _fromCol + 1);
                    default:
                        return 1;
                }
            }
        }
        /// <summary>
        /// Returns type of this element collection
        /// </summary>
        public UsedRangeElement Element
        {
            get { return element; }
        }
        /// <summary>
        /// Returns parent type of element this collection
        /// </summary>
        public UsedRangeElement ParentElement
        {
            get { return parentElement; }
        }
        #endregion
        #region private methods
        /// <summary>
        /// Validates row index for row collection
        /// added by mukesh
        /// </summary>
        /// <param name="Row"></param>
        private void ValidateRow(int Row)
        {
            if (Row < 0 || Row > ExcelPackage.MaxRows)
            {
                throw (new ArgumentException("Row out of range"));
            }
        }
        /// <summary>
        /// Validates column index for column collection
        /// added by mukesh
        /// </summary>
        /// <param name="Col"></param>
        private void ValidateCol(int Col)
        {
            if (Col < 0 || Col > ExcelPackage.MaxColumns)
            {
                throw (new ArgumentException("Column out of range"));
            }
        }
        /// <summary>
        /// Validates cell index for cell collection
        /// added by mukesh
        /// </summary>
        /// <param name="Cell"></param>
        private void ValidateCell(long Cell)
        {
            if (Cell <0 || Cell > UsedRange.MaxCells)
            {
                throw (new ArgumentException("Cell out of range"));
            }
        }
        /// <summary>
        /// converts cell index into a point consists of row and column index.
        /// added by mukesh
        /// </summary>
        /// <param name="Cell"></param>
        private void CellToAddress(long Cell)
        {
            long rc = ((_worksheet._cells[_worksheet._cells.Count - 1] as ExcelCell).Row
                        - (_worksheet._cells[0] as ExcelCell).Row) + 1;
            long cc = _worksheet._maxCol - _worksheet._minCol + 1;
            elementIndex = (int)(Cell / cc) + 1;
            cursor = (int)(Cell % cc) + 1;
        }
        /// <summary>
        /// This method is added by mukesh
        /// </summary>
        /// <returns>
        /// Excel Range Object
        /// </returns>
        ExcelRange SetRange()
        {
            switch (element)
            {
                case UsedRangeElement.Rows:
                case UsedRangeElement.Columns:
                case UsedRangeElement.Cells:
                    return this[(_worksheet._cells[0] as ExcelCell).Row, _worksheet._minCol,
                    (this._worksheet._cells[_worksheet._cells.Count - 1] as ExcelCell).Row,
                    _worksheet._maxCol];
                case UsedRangeElement.Row:
                    return this[elementIndex + 1, _worksheet._minCol, elementIndex + 1, _worksheet._maxCol];
                case UsedRangeElement.Column:
                    return this[(_worksheet._cells[0] as ExcelCell).Row, elementIndex + 1,
                    (_worksheet._cells[_worksheet._cells.Count - 1] as ExcelCell).Row, elementIndex + 1];
                case UsedRangeElement.RowCell:
                case UsedRangeElement.Cell:
                    return this[elementIndex + 1, cursor + 1];
                case UsedRangeElement.ColumnCell:
                    return this[cursor + 1, elementIndex + 1];
                default:
                    return this;
            }
        }
        #endregion
        #region internal static methods
        /// <summary>
        /// these static methods will be used to return row collection from worksheet
        /// added by mukesh
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        internal static UsedRange RowCollection(ExcelWorksheet sheet)
        {
            return new UsedRange(sheet, UsedRangeElement.Rows);
        }
        /// <summary>
        /// these static methods will be used to return column collection from worksheet
        /// added by mukesh
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        internal static UsedRange ColumnCollection(ExcelWorksheet sheet)
        {
            return new UsedRange(sheet, UsedRangeElement.Columns);
        }
        /// <summary>
        /// these static methods will be used to return cell collection from worksheet
        /// added by mukesh
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        internal static UsedRange CellCollection(ExcelWorksheet sheet)
        {
            return new UsedRange(sheet, UsedRangeElement.Cells);
        }
        #endregion
        #region ienumerable implementation
        public new IEnumerator<UsedRange> GetEnumerator()
        {
            position = -1;
            for (int i = 0; i < Count; i++)
            {
                ++position;
                yield return this[i];
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
        /// <summary>
        /// Determine Type of Used range element. 
        /// Being used to return RowCollection, ColumnCollection, CellCollection or single Row, Column or Cell
        /// added by mukesh
        /// </summary>
        public enum UsedRangeElement
        {
            Range, Rows, Columns, Cells,
            Row, Column, Cell, RowCell, ColumnCell
        }
    }
    public sealed partial class ExcelWorksheet : XmlHelper
    {
        /// <summary>
        /// Provides access to a range of used rows
        /// </summary>  
        public UsedRange UsedRows
        {
            get
            {
                return UsedRange.RowCollection(this);
            }
        }
        /// <summary>
        /// Provides access to a range of used columns. added by mukesh
        /// </summary>  
        public UsedRange UsedColumns
        {
            get
            {
                return UsedRange.ColumnCollection(this);
            }
        }
        /// <summary>
        /// Provides access to a range of used cells. added by mukesh
        /// </summary>  
        public UsedRange UsedCells
        {
            get
            {
                return UsedRange.CellCollection(this);
            }
        }
        /// <summary>
        /// UsedRange object of the worksheet. added by mukesh
        /// this range contains used Top left cell to Bottom right.
        /// If the worksheet has no cells, null is returned
        /// </summary>
    }
    }
