     static void Main(string[] args)
        {
            if (args == null || args.Length < 3)
            {
                Console.WriteLine("Wrong Input");
                return;
            }
            if (!ValidateFilePath(args[0]) || !ValidateFilePath(args[1]))
            {
                return;
            }
            Dictionary<int, double> parsedFileData = new Dictionary<int, double>();
            
            //Read the first file
            ReadFileData(args[0], parsedFileData);
            //Read second file 
            ReadFileData(args[1], parsedFileData);
            //Write to third file
            WriteFileData(args[2], parsedFileData);
        }
        private static bool ValidateFilePath(string filePath)
        {
            try
            {
                return File.Exists(filePath);
            }
            catch (Exception)
            {
                Console.WriteLine($"Failed to read file : {filePath}");
                return false;
            }
        }
        private static void ReadFileData(string filePath, Dictionary<int, double> parsedFileData)
        {
            try
            {
                using (StreamReader fileStream = new StreamReader(filePath))
                {
                    string line;
                    while ((line = fileStream.ReadLine()) != null)
                    {
                        string[] currentLine = line.Split('|');
                        int index = Convert.ToInt16(currentLine[0]);
                        double value = Convert.ToDouble(currentLine[1]);
                        parsedFileData.Add(index, value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception : {ex.Message}");
            }
        }
        private static void WriteFileData(string filePath, Dictionary<int, double> parsedFileData)
        {
            try
            {
                using (StreamWriter fileStream = new StreamWriter(filePath))
                {
                    foreach (var parsedLine in parsedFileData)
                    {
                        var line = parsedLine.Key + "|" + parsedLine.Value;
                        fileStream.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception : {ex.Message}");
            }
        }
