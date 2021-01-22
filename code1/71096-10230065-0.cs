            lookup = new bool[123];
            for (var c = '0'; c <= '9'; c++)
            { lookup[c] = true; System.Diagnostics.Debug.WriteLine((int)c + ": " + (char)c); }
            for (var c = 'A'; c <= 'Z'; c++)
            { lookup[c] = true; System.Diagnostics.Debug.WriteLine((int)c + ": " + (char)c); }
            for (var c = 'a'; c <= 'z'; c++)
            { lookup[c] = true; System.Diagnostics.Debug.WriteLine((int)c + ": " + (char)c); }
