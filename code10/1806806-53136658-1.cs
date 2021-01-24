    public ReadTxtFileResult ReadTxtFile(string Flepath)
    {
        Stack stk = new Stack();
        DataTable dt = new DataTable();
        return new ReadTxtFileResult
        {
            Stack = stk,
            DataTable = dt
        }
    }
