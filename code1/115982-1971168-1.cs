    using (var fs = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite)))
            {
                var destinationReader = StreamReader(fs);
                var writer = StreamWriter(fs);
                while ((line = reader.ReadLine()) != null)
                {rif (line_number == line_to_edit)
                    {
                        writer.WriteLine(lineToWrite);
                    }
                    else
                    {
                        destinationReader .ReadLine();
                    }
                    line_number++;
                }
            }
