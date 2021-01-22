    public void CreateDatabase(string sPath)
    {
        // Get the resource and, er write it out?
        System.IO.Stream DBStream;
        System.IO.StreamReader dbReader;
        System.IO.FileStream OutputStream;
                            
        OutputStream = new FileStream(sPath, FileMode.Create);
        Assembly ass = System.Reflection.Assembly.GetAssembly(this.GetType());
        DBStream = ass.GetManifestResourceStream("SoftwareByMurph.blank.mdb");
        dbReader = new StreamReader(DBStream);
        for(int l=0;l < DBStream.Length;l++)
        {
            OutputStream.WriteByte((byte)DBStream.ReadByte());
        }
        OutputStream.Close();
    }
