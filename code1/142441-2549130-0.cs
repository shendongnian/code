    class StyleDefinition
        {
            public string Property { get; set; }
            public string Value { get; set; }
    
            public StyleDefinition(string p, string v)
            {
                Property = p;
                Value = v;
            }
        }
    
        class Cell {
            public List<StyleDefinition> Styles { get; set; }
            public string Value { get; set; }
        }
    
        class CellBuilder
        {
            public Cell CreateCell(List<StyleDefinition> styles, string value)
            {
                return new Cell { Styles = styles, Value = value };
            }
    
            public List<Cell> CreateRow(Dictionary<int, List<StyleDefinition>> styles, IEnumerable<string> values)
            {
                var res = new List<Cell>();
                var it = values.GetEnumerator();
                foreach( var kp in styles) {
                    // logic for cell with key = kp.Key
                    res.Add(CreateCell(kp.Value, it.Current));
                    it.MoveNext();
                }
    
                return res;
            }
    
            public List<List<Cell>> CreateTable(Dictionary<int, Dictionary<int, List<StyleDefinition>>> styles, IEnumerable<IEnumerable<string>> values)
            {
                var res = new List<List<Cell>>();
                var it = values.GetEnumerator();
                foreach (var kp in styles)
                {                            
                    res.Add(CreateRow(kp.Value, it.Current));
                    it.MoveNext();
                }
    
                return res;
            }
    
        }
