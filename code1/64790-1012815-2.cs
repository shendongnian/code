    static string NextColumn(string column){
        char[] c = column.ToCharArray();
        for(int i = c.Length - 1; i >= 0; i--){
            if(char.ToUpper(c[i]++) < 'Z')
                break;
            c[i] -= (char)26;
            if(i == 0)
                return "A" + new string(c);
        }
        return new string(c);
    }
