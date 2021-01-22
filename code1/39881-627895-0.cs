    public static void Sort(this NameValueCollection nameValueCollection)
        {
            // Create a temporary collection the same size as the original
            NameValueCollection tempNameValueCollection = new NameValueCollection(nameValueCollection.Count);
            // Sort the keys
            string[] keys = nameValueCollection.AllKeys;
            Array.Sort(keys);
            foreach (string key in keys)
            {
                // Sort the values
                string[] values = nameValueCollection[key].Split(',');
                Array.Sort(values);
                // Add each value to the temporary collection
                foreach (string value in values)
                {
                    tempNameValueCollection.Add(key, value);
                }
            }
            // Clear the original collection
            nameValueCollection.Clear();
            // Add the sorted entries back
            nameValueCollection.Add(tempNameValueCollection);
        }
