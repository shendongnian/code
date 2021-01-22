        private static void RemoveNotPermittedItems(IDictionary<string, IActionItem> menu)
        {
            var keysToRemove = new List<string>();
            foreach (var item in menu)
            {
                if (GetIsPermitted(item.Value.Call))
                {
                    var value = item.Value as ActionDictionary;
                    if (value != null)
                    {
                        RemoveNotPermittedItems(value);
                        if (!value.Any())
                        {
                            keysToRemove.Add(item.Key);
                        }
                    }
                }
                else
                {
                    keysToRemove.Add(item.Key);
                }
            }
            keysToRemove.ForEach(key => menu.Remove(key));
        }
        private static bool GetIsPermitted(object call)
        {
            return ...;
        }
