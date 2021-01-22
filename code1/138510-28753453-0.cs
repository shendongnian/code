    using (var reader = new SqlCommandReader(scriptContents))
           {
                var commands = new List<string>();
                reader.ReadAllCommands(c => commands.Add(c));
                // commands now contains each individual sql batch.
            }
