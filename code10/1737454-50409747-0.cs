    public static string[] selectAGIdOfKC(string id)
    {
        int nbAg = 0;
        ...
        nbAg = results.Rows.Count();
        string[] myTab = new string[nbAg];
        for (int i = 0; i < nbAg; i++)
        {
            myTab[i] = results.Rows[i][0].ToString(); 
                       // This is the first column of row i
        }
        return myTab;
    }
