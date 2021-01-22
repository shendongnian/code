    // 0-based indexes
    static string RcToA1(int row, int col)
    {
        string toRet = "";
        int mag = 0;
        while(col >= Math.Pow(26, mag+1)){mag++;}
        while (mag>0)
        {
            toRet += System.Convert.ToChar(64 + (byte)Math.Truncate((double)(col/(Math.Pow(26,mag)))));
            col -= (int)Math.Truncate((double)Math.Pow(26, mag--));
        }
        toRet += System.Convert.ToChar(65 + col);
        return toRet + (row + 1).ToString();
    }
    static Random rand = new Random(DateTime.Now.Millisecond);
    static string RandomExcelFormat()
    {
        switch ((int)Math.Round(rand.NextDouble(),0))
        {
            case 0: return "0.00%";
            default: return "0.00";
        }
    }
    struct ExcelFormatSpecifier
    {
        public object NumberFormat;
        public string RangeAddress;
    }
    static void DoWork()
    {
        List<ExcelFormatSpecifier> NumberFormatList = new List<ExcelFormatSpecifier>(0);
        object[,] rangeData = new object[rows,cols];
        for(int r = 0; r < rows; r++)
        {
            for(int c = 0; c < cols; c++)
            {
                someVal = r + c;
                rangeData[r,c] = someVal.ToString();
                NumberFormatList.Add(new ExcelFormatSpecifier
                    {
                        NumberFormat = RandomExcelFormat(),
                        RangeAddress = RcToA1(rowIndex, colIndex)
                    });
            }
        }
        range.set_Value(MissingValue, rangeData);
        int max_format = 50;
        foreach (string formatSpecifier in NumberFormatList.Select(p => p.NumberFormat).Distinct())
        {
            List<string> addresses = NumberFormatList.Where(p => p.NumberFormat == formatSpecifier).Select(p => p.RangeAddress).ToList();
            while (addresses.Count > 0)
            {
                string addressSpecifier = string.Join(",",     addresses.Take(max_format).ToArray());
                range.get_Range(addressSpecifier, MissingValue).NumberFormat = formatSpecifier;
                addresses = addresses.Skip(max_format).ToList();
            }
        }
    }
