    public int GetCreatedVersion(string mdbPath)
    {
        dao.DBEngine engine = new dao.DBEngine();
        dao.Database db = engine.OpenDatabase(mdbPath, false, false, "");
        string versionString = db.Properties["AccessVersion"].Value.ToString();
        int version = 0;
        int projVer = 0;
        switch (versionString.Substring(0, 2))
        {
            case "02":
                version = 2; break;
            case "06":
                version = 7; break;
            case "07":
                version = 8; break;
            case "08":
                foreach (dao.Property prop in db.Properties)
                {
                    if (prop.Name == "ProjVer")
                    {
                        projVer = int.Parse(prop.Value.ToString());
                        break;
                    }
                }
                switch (projVer)
                {
                    case 0:
                        version = 9; break;
                    case 24:
                        version = 10; break;
                    case 35:
                        version = 11; break;
                    default:
                        version = -1; break;                            
                }
                break;
            case "09":
                foreach (dao.Property prop in db.Properties)
                {
                    if (prop.Name == "ProjVer")
                    {
                        projVer = int.Parse(prop.Value.ToString());
                        break;
                    }
                }
                switch (projVer)
                {
                    case 0:
                        version = 10; break;
                    case 24:
                        version = 10; break;
                    case 35:
                        version = 11; break;
                    default:
                        version = -1; break;
                }
                break;
        }
        db.Close();
        
        return version;
    }
