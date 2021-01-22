        private static readonly HashSet<char> invalidFileNameChars = new HashSet<char>(Path.GetInvalidFileNameChars());
        public static string RemoveInvalidFileNameChars(string name)
        {
            if (!name.Any(c => invalidFileNameChars.Contains(c))) {
                return name;
            }
            return new string(name.Where(c => !invalidFileNameChars.Contains(c)).ToArray());
        }
