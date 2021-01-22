    static void Main(string[] args)
        {
            List<Element> Elements = new List<Element>();
            Elements.Add(new Element("abc_"));
            Elements.Add(new Element("abc2_"));
            Elements.Add(new Element("aaa"));
            var max = Elements.Max(e => e.Name.Length);
            var result = Elements.OrderBy(e => e.Name, new CustomComparer(max));
            foreach (var item in result)
                Console.WriteLine(item.Name);
            Console.Read();
        }
        class Element
        {
            public string Name { get; private set; }
            public Element(string name)
            {
                this.Name = name;
            }
        }
        class CustomComparer : Comparer<string>
        {
            private const string cWildCard = "_";
            private const char cHeavyChar = 'Z';
            public int Max { get; private set; }
            public CustomComparer(int max)
            {
                this.Max = max;
            }
            public override int Compare(string a, string b)
            {
                string comp1 = string.Empty, comp2 = string.Empty;
                int index = a.IndexOf(cWildCard);
                if (index > 0)
                    comp1 = a.Substring(0, index).PadRight(this.Max, cHeavyChar);
                index = b.IndexOf(cWildCard);
                if (index > 0)
                    comp2 = b.Substring(0, index).PadRight(this.Max, cHeavyChar);
                int result = comp1.CompareTo(comp2);
                return result;
            }
        }
