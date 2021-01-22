    class ExcelDataWrapper
    {
        private object[,] _excelData;
        public ExcelDataWrapper(object[,] excelData)
        {
            _excelData = excelData;
        }
        public object this[int x, int y]
        {
            return _excelData[x+1, y+1];
        }
    }
