    public class ListViewItemComparer : IComparer
    {
        private int _columnIndex;
        public int ColumnIndex
        {
            get
            {
                return _columnIndex;
            }
            set
            {
                _columnIndex = value;
            }
        }
        private SortOrder _sortDirection;
        public SortOrder SortDirection
        {
            get
            {
                return _sortDirection;
            }
            set
            {
                _sortDirection = value;
            }
        }
        private ColumnDataType _columnType;
        public ColumnDataType ColumnType
        {
            get
            {
                return _columnType;
            }
            set
            {
                _columnType = value;
            }
        }
        
        public ListViewItemComparer()
        {
            _sortDirection = SortOrder.None;
        }
        public int Compare(object x, object y)
        {
            ListViewItem lviX = x as ListViewItem;
            ListViewItem lviY = y as ListViewItem;
            int result;
            if (lviX == null && lviY == null)
            {
                result = 0;
            }
            else if (lviX == null)
            {
                result = -1;
            }
            else if (lviY == null)
            {
                result = 1;
            }
            switch (ColumnType)
            {
                case ColumnDataType.DateTime:
                    DateTime xDt = DataParseUtility.ParseDate(lviX.SubItems[ColumnIndex].Text);
                    DateTime yDt = DataParseUtility.ParseDate(lviY.SubItems[ColumnIndex].Text);
                    result = DateTime.Compare(xDt, yDt);
                    break;
                case ColumnDataType.Decimal:
                    Decimal xD = DataParseUtility.ParseDecimal(lviX.SubItems[ColumnIndex].Text.Replace("$", string.Empty).Replace(",", string.Empty));
                    Decimal yD = DataParseUtility.ParseDecimal(lviY.SubItems[ColumnIndex].Text.Replace("$", string.Empty).Replace(",", string.Empty));
                    result = Decimal.Compare(xD, yD);
                    break;
                case ColumnDataType.Short:
                    short xShort = DataParseUtility.ParseShort(lviX.SubItems[ColumnIndex].Text);
                    short yShort = DataParseUtility.ParseShort(lviY.SubItems[ColumnIndex].Text);
                    result = xShort.CompareTo(yShort);
                    break;
                case ColumnDataType.Int:
                    int xInt = DataParseUtility.ParseInt(lviX.SubItems[ColumnIndex].Text);
                    int yInt = DataParseUtility.ParseInt(lviY.SubItems[ColumnIndex].Text);
                    return xInt.CompareTo(yInt);
                    break;
                case ColumnDataType.Long:
                    long xLong = DataParseUtility.ParseLong(lviX.SubItems[ColumnIndex].Text);
                    long yLong = DataParseUtility.ParseLong(lviY.SubItems[ColumnIndex].Text);
                    return xLong.CompareTo(yLong);
                    break;
                default:
                    
                    result = string.Compare(
                        lviX.SubItems[ColumnIndex].Text,
                        lviY.SubItems[ColumnIndex].Text,
                        false);
                    break;
            }
            if (SortDirection == SortOrder.Descending)
            {
                return -result;
            }
            else
            {
                return result;
            }
        }
    }
