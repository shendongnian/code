    public static class CheckVfpOleDb
    {
        public static bool IsInstalled()
        {
            return Registry.ClassesRoot.OpenSubKey("TypeLib\\{50BAEECA-ED25-11D2-B97B-000000000000}") != null;
        }
    }
