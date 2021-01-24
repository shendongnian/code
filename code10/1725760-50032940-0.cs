    public static bool Ping()
    {
               var proc = Process.GetProcessesByName("3DEXPERIENCE");
                return proc[0].Responding;
     }
