    enum OS { _2000, XP, Vista, _7, _8 }
    public static OS GetOS()
    {
        var version = Environment.OSVersion.Version;
        switch (version.Major)
        {
            case 5:
                switch (version.Minor)
                {
                    case 0:
                        return OS._2000;
                    case 1:
                        return OS.XP;
                    case 2:
                        return OS.XP; //could also be Server 2003, Server 2003 R2
                }
                break;
            case 6:
                switch (version.Minor)
                {
                    case 0:
                        return OS.Vista; //could also be Server 2008
                    case 1:
                        return OS._7; //could also be Server 2008 R2
                    case 2:
                        return OS._8; //could also be Server 20012, Server 2012 R2
                }
                break;
        }
        throw new Exception("Strange OS");
    }
