    using (StreamWriter sw = new StreamWriter(@"C:\file.csv"))
    {
        StringBuilder csvLine = new StringBuilder();
    
        //Enter your header row here:
        csvLine.Append("Header1,Header2,Header3");
        sw.WriteLine(csvLine.ToString());
        foreach (Product product in Products)
        {
            csvLine = new StringBuilder();
            csvLine.Append(string.Format("{0},", product.Value1));
            csvLine.Append(string.Format("{0},", product.Value2));
            csvLine.Append(string.Format("{0}", product.Value3)); //etc
            sw.WriteLine(csvLine.ToString());
        }
        sw.Flush();
    }
