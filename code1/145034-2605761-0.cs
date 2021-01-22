    public bool TryParseTable(HtmlNode table, out DataTable result){
        // your code...
        if(success)
        {
            result = //the table you parsed
            return true;
        }
        else
        {
            result = null;
            return false;
        }
    }
