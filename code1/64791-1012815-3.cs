    static string GetColumnName(int index){
        StringBuilder txt = new StringBuilder();
        txt.Append((char)('A' + index % 26));
        //txt.Append((char)('A' + --index % 26));
        while((index /= 26) > 0)
            txt.Insert(0, (char)('A' + --index % 26));
        return txt.ToString();
    }
    static int GetColumnIndex(string name){
        int rtn = 0;
        foreach(char c in name)
            rtn = rtn * 26 + (char.ToUpper(c) - '@');
        return rtn - 1;
        //return rtn;
    }
