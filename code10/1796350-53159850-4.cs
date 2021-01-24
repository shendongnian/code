    private string FilterStringconverter(string filter)
    {
        string newColFilter = "";
    
        filter = filter.Replace("(", "").Replace(")","");
    
        var colFilterList = filter.Split(new string[] { "AND" }, StringSplitOptions.None);
    
        string andOperator = "";
    
        foreach ( var colFilter in colFilterList)
        {
            newColFilter += andOperator;
    
            var temp1 = colFilter.Trim().Split(new string[] { "IN" }, StringSplitOptions.None);
    
            var colName = temp1[0].Replace("[", "").Replace("]", "").Trim();
    
            colName = colName.Split(' ')[0];
    
            var filterValsList = temp1[1].Split(',');
    
            newColFilter += string.Format("({0} != null && (", colName);
    
            string orOperator = "";
    
            foreach ( var filterVal in filterValsList)
            {
                newColFilter += string.Format("{0} {1}.Contains({2})", orOperator, colName, filterVal.Trim());
    
                orOperator = " OR ";
            }
    
            newColFilter += "))";
    
            andOperator = " AND ";
        }
    
        return newColFilter.Replace("'", "\"");
    }
