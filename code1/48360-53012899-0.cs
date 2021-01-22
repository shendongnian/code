        var memory = 0.0;
        using (Process proc = Process.GetCurrentProcess())
        {
            // The proc.PrivateMemorySize64 will returns the private memory usage in byte.
            // Would like to Convert it to Megabyte? divide it by 1e+6
               memory = proc.PrivateMemorySize64 / 1e+6;
        }
