        private Dictionary<string, string> GetExtendedProperties(string filePath)
        {
            var directory = Path.GetDirectoryName(filePath);
            var shellFolder = new Shell32.Shell().NameSpace(directory);
            var fileName = Path.GetFileName(filePath);
            var folderitem = shellFolder.ParseName(fileName);
            var dictionary = new Dictionary<string, string>();
            var i = 0;
            while (true)
            {
                var header = shellFolder.GetDetailsOf(null, i);
                if (String.IsNullOrEmpty(header)) break;
                var value = shellFolder.GetDetailsOf(folderitem, i);
                if (!dictionary.ContainsKey(header)) dictionary.Add(header, value);
                Console.WriteLine(header +": " + value);
                i++;
            }
            return dictionary;
        }
