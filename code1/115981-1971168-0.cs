    using (var fs = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite)))
            {
                var reader = StreamReader(fs);
                var writer = StreamWriter(fs);
                while ((line = reader.ReadLine()) != null)
                {
                    if (line_number == line_to_edit)
                    {
                        writer.WriteLine(lineToWrite);
                    }
                    else
                    {
                        reader.ReadLine();
                    }
                    line_number++;
                }
            }
