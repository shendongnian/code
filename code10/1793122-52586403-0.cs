                if (File.Exists(marksfile))
                {
                    FileStream fs = new FileStream(marksfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using (var reader = new StreamReader(fs))
                    {
                        _marks.ReadXml(reader);
                    }
                }
