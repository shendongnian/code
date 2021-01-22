    static TDAPIOLELib.Recordset GetRecSet(String Qry, TDAPIOLELib.TDConnection TD)
            {
    
                TDAPIOLELib.Command Com;
                Com = TD.Command as TDAPIOLELib.Command;
                Com.CommandText = Qry;
    
                TDAPIOLELib.Recordset RecSet = Com.Execute() as TDAPIOLELib.Recordset;
                return RecSet;
    
            }
