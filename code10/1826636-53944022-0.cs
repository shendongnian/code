            List<string> strings = new List<string>()
            {
                "Data Source = 192.123.21.2\\sql2014",
                "Initial Catalog = IPETDB",
                "User ID = sa",
                "Password = M******",
                "Connection Timeout = 5"
            };
            foreach (var str in strings)
            {
                var tokens = str.Split('=');
                if (tokens.Length != 2)
                    continue;
                if (tokens[0].Trim() == "Initial Catalog")
                    DBName = tokens[1].Trim();
            }
