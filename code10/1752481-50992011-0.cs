        public class Attributes
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string ListType { get; set; }
            private List<string> _ComboBoxValue { get;set;}
            public string ComboBoxValue
            {
                get
                {
                    return "[\"" + string.Join("\",\"", _ComboBoxValue) + "\"]";
                }
                set
                {
                    _ComboBoxValue = value.Split(new char[] { '[', ',', ']' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
            }
        }
