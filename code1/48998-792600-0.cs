    String binDir = Server.MapPath("/bin/");
    Response.Write(String.Format("Bin dir:{0}<br/><br/>",binDir));
    foreach (string file in Directory.GetFiles(binDir, "*.dll"))
    {
        Response.Write(String.Format("File:{0}<br/>", file));
        try
        {
            Assembly assembly = Assembly.LoadFile(file);
            object[] attrinutes = assembly.GetCustomAttributes(true);
            foreach (var o in attrinutes)
            {
                //AssemblyCompanyAttribute is set in the AssemblyInfo.cs
                if (o is AssemblyCompanyAttribute)
                {
                    Response.Write(String.Format("Company Attribute: Company = {0}<br/>", ((AssemblyCompanyAttribute)o).Company));
                    continue;   
                }
                Response.Write(String.Format("Attribute: {0}<br/>", o));
            }
        }
        catch(Exception ex)
        {
            Response.Write(String.Format("Exception Reading File: {0} Exception: {1}",file,ex));
        }
    }
