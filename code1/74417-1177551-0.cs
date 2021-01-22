        private bool IsDuplicate<T>(T entityProperty, Hashtable properties)
        {
            bool res = true;
            foreach (DictionaryEntry prop in properties)
            {
                var curValue = getPropertyValue(entityProperty, prop.Key.ToString());
                if (prop.Value.Equals(curValue))
                {
                    res &= true;
                }
                else
                    res &= false;
            }
            return res;
        }
