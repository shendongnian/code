     public void gettrust()
        {
            string str_TR = (string)Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("TRUSTEDPATHS");
            string C_Paths = str_TR.ToLower();
            List<string> Old_Path_Ary = new List<string>();
            Old_Path_Ary = new List<string>(C_Paths.Split(new char[] { ';' }));
            String curfile = System.Reflection.Assembly.GetExecutingAssembly().Location;
            String curDirectory = System.IO.Path.GetDirectoryName(curfile);   //the directory need to add.
            if (!Old_Path_Ary.Contains(curDirectory))
            {
                Old_Path_Ary.Add(curDirectory);
            }
            Autodesk.AutoCAD.ApplicationServices.Application.SetSystemVariable("TRUSTEDPATHS", string.Join(";", Old_Path_Ary.ToArray()));
        }
