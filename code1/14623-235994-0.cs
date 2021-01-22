        static int counter = 0;
        private static void RemoveNotPermittedItems(Dictionary<string, object> menu)
        {
            for (int c = menu.Count - 1; c >= 0; c--)
            {
                var key = menu.Keys.ElementAt(c);
                var value = menu[key];
                if (value is Dictionary<string, object>)
                {
                    RemoveNotPermittedItems((Dictionary<string, object>)value);
                    if (((Dictionary<string, object>)value).Count == 0)
                    {
                        menu.Remove(key);
                    }
                }
                else if (!GetIsPermitted(value))
                {
                    menu.Remove(key);
                }
            }
        }
        // This just added to actually cause some elements to be removed...
        private static bool GetIsPermitted(object value)
        {
            if (counter++ % 2 == 0)
                return false;
            return true;
        }
