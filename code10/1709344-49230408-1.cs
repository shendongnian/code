    public class MyDictionary : List<ExcellData>
        {
            public void Add(string key, string Name, string Title)
            {
                ExcellData val = new ExcellData();
                val.Name= Name;
                val.Title= Title;
                this.Add(val);
            }
        }
