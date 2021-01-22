    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class StringIndex
    {
        private Dictionary<char, Item> _rootChars;
        public StringIndex()
        {
            _rootChars = new Dictionary<char, Item>();
        }
        public void Add(string value, string data)
        {
            int level = 0;
            Dictionary<char, Item> currentChars = _rootChars;
            Item currentItem = null;
            foreach (char c in value)
            {
                if (currentChars.ContainsKey(c))
                {
                    currentItem = currentChars[c];
                }
                else
                {
                    currentItem = new Item() { Level = level, Letter = c };
                    currentChars.Add(c, currentItem);                
                }
                currentChars = currentItem.Items;
                level++;
            }
            if (!currentItem.Values.Contains(data))
            {
                currentItem.Values.Add(data);
                IncrementCount(value);
            }
        }
        private void IncrementCount(string value)
        {
            Dictionary<char, Item> currentChars = _rootChars;
            Item currentItem = null;
            foreach (char c in value)
            {
                currentItem = currentChars[c];
                currentItem.Total++;
                currentChars = currentItem.Items;
            }
        }
        public void Remove(string value, string data)
        {
            Dictionary<char, Item> currentChars = _rootChars;
            Dictionary<char, Item> parentChars = null;
            Item currentItem = null;
            foreach (char c in value)
            {
                if (currentChars.ContainsKey(c))
                {
                    currentItem = currentChars[c];
                    parentChars = currentChars;
                    currentChars = currentItem.Items;
                }
                else
                {
                    return; // no matches found
                }
            }
            if (currentItem.Values.Contains(data))
            {
                currentItem.Values.Remove(data);
                DecrementCount(value);
                if (currentItem.Total == 0)
                {
                    parentChars.Remove(currentItem.Letter);
                }
            }
        }
        private void DecrementCount(string value)
        {
            Dictionary<char, Item> currentChars = _rootChars;
            Item currentItem = null;
            foreach (char c in value)
            {
                currentItem = currentChars[c];
                currentItem.Total--;
                currentChars = currentItem.Items;
            }
        }
        public void Clear()
        {
            _rootChars.Clear();
        }
        public int GetValuesByPrefixCount(string prefix)
        {
            int valuescount = 0;
            int level = 0;
            Dictionary<char, Item> currentChars = _rootChars;
            Item currentItem = null;
            foreach (char c in prefix)
            {
                if (currentChars.ContainsKey(c))
                {
                    currentItem = currentChars[c];
                    currentChars = currentItem.Items;
                }
                else
                {
                    return valuescount; // no matches found
                }
                level++;
            }
            valuescount = currentItem.Total;
        
            return valuescount;
        }
        public HashSet<string> GetValuesByPrefixFlattened(string prefix)
        {
            var results = GetValuesByPrefix(prefix);
            return new HashSet<string>(results.SelectMany(x => x));
        }
        public List<HashSet<string>> GetValuesByPrefix(string prefix)
        {
            var values = new List<HashSet<string>>();
            int level = 0;
            Dictionary<char, Item> currentChars = _rootChars;
            Item currentItem = null;
            foreach (char c in prefix)
            {
                if (currentChars.ContainsKey(c))
                {
                    currentItem = currentChars[c];
                    currentChars = currentItem.Items;
                }
                else
                {
                    return values; // no matches found
                }
                level++;
            }
            ExtractValues(values, currentItem);
            return values;
        }
        public void ExtractValues(List<HashSet<string>> values, Item item)
        {
            foreach (Item subitem in item.Items.Values)
            {
                ExtractValues(values, subitem);
            }
            values.Add(item.Values);
        }
        public class Item
        {
            public int Level { get; set; }
            public char Letter { get; set; }
            public int Total { get; set; }
            public HashSet<string> Values { get; set; }
            public Dictionary<char, Item> Items { get; set; }
            public Item()
            {
                Values = new HashSet<string>();
                Items = new Dictionary<char, Item>();
            }
        }
    }
