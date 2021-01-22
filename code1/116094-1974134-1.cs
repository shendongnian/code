            string path = @"C:\TEXTFILES\";
            string path2 = @"P:\myNetworkPath\tesssst";
            try
            {
                Directory.CreateDirectory(path2);
                foreach (string fileName in Directory.GetFiles(path))
                {
                    File.Copy(
                        Path.Combine(path, fileName),
                        Path.Combine(path2, fileName), true);
                }
            }
            catch
            {
                Console.WriteLine("Exception");
            }
