    namespace XLS
    {
    /// <summary>
    /// Represents a single cell in a excell sheet
    /// </summary>
    public struct Cell
    {
        private long row;
        private long column;
        private string columnAddress;
        private string address;
        private bool dataChange;
        /// <summary>
        /// Initializes a new instance of the XLS.Cell 
        /// class with the specified row and column of excel worksheet
        /// </summary>
        /// <param name="row">The row index of a cell</param>
        /// <param name="column">The column index of a cell</param>
        public Cell(long row, long column)
        {
            this.row = row;
            this.column = column;
            dataChange = true;
            address = string.Empty;
            columnAddress = string.Empty;
        }
        /// <summary>
        /// Initializes a new instance of the XLS.Cell
        /// class with the specified address of excel worksheet
        /// </summary>
        /// <param name="address">The adress of a cell</param>
        public Cell(string address)
        {
            this.address = address;
            dataChange = false;
            row = GetRow(address);
            columnAddress = GetColumnAddress(address);
            column = GetColumn(columnAddress);
        }
        /// <summary>
        /// Gets or sets the row of this XLS.Cell
        /// </summary>
        public long Row
        {
            get { return row <= 0 ? 1 : row; }
            set { row = value; dataChange = true; }
        }
        /// <summary>
        /// Gets or sets the column of this XLS.Cell
        /// </summary>
        public long Column
        {
            get { return column <= 0 ? 1 : column; }
            set { column = value; dataChange = true; }
        }
        /// <summary>
        /// Gets or sets the address of this XLS.Cell
        /// </summary>
        public string Address
        {
            get { return dataChange ? ToAddress() : address; }
            set
            {
                address = value;
                row = GetRow(address);
                column = GetColumn(address);
            }
        }
        /// <summary>
        /// Gets the column address of this XLS.Cell
        /// </summary>
        public string ColumnAddress
        {
            get { return GetColumnAddress(Address); }
            private set { columnAddress = value; }
        }
        #region Private Methods
        private static long GetRow(string address)
        {
            return long.Parse(address.Substring(GetStartIndex(address)));
        }
        private static string GetColumnAddress(string address)
        {
            return address.Substring(0, GetStartIndex(address)).ToUpperInvariant();
        }
        private static long GetColumn(string columnAddress)
        {
            char[] characters = columnAddress.ToCharArray();
            int sum = 0;
            for (int i = 0; i < characters.Length; i++)
            {
                sum *= 26;
                sum += (characters[i] - 'A' + 1);
            }
            return (long)sum;
        }
        private static int GetStartIndex(string address)
        {
            return address.IndexOfAny("123456789".ToCharArray());
        }
        private string ToAddress()
        {
            string indexToString = string.Empty;
            if (Column > 26)
            {
                indexToString = ((char)(65 + (int)((Column - 1) / 26) - 1)).ToString();
            }
            indexToString += (char)(65 + ((Column - 1) % 26));
            dataChange = false;
            return indexToString + Row;
        }
        #endregion
    }
   }
