        private Dictionary<string, int> instanceCounts = new Dictionary<string, int>();
        private string GetNextName(string baseName)
        {
            int count = 1;
            if (instanceCounts.TryGetValue(baseName, out count))
            {
                // the thing already exists, so add one to it
                count++;
            }
            // update the dictionary with the new value
            instanceCounts[baseName] = count;
            // format the number as desired
            return baseName + count.ToString("00");
        }
