        string a = "a;b;c;d;e;v";
        string[] b = a.Split(';');
        string[] c = b.Distinct().ToArray();
        if (b.Length != c.Length)
        {
            for (int i = 0; i < b.Length; i++)
            {
                try
                {
                    if (b[i].ToString() != c[i].ToString())
                    {
                        Response.Write("Found duplicate " + b[i].ToString());
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Found duplicate " + b[i].ToString());
                    return;
 
                }
            }
               
        }
        else
        {
            Response.Write("No duplicate ");
        }
        
    }
