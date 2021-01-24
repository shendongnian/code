     public struct ExcellCells
        {
            public string Someoption { get; set; }
            public string SomeOptionType { get; set; }
            public string[] cellList { get; set; }
        }
        public class MyDictionary : List<ExcellCells>
        {
            public void Add(string key, string option, string[] xcell)
            {
                ExcellCells val = new ExcellCells();
                val.SomeOptionType = key;
                val.Someoption = option;
                val.cellList = xcell;
                this.Add(val);
            }
        }
