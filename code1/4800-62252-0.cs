    public class DropDownData
    {
        enum Responses { Yes = 1, No = 2, Maybe = 3 }
    
        public String Text { get; set; }
        public int Value { get; set; }
    
        public List<DropDownData> GetList()
        {
            var items = new List<DropDownData>();
            foreach (int value in Enum.GetValues(typeof(Responses)))
            {
                items.Add(new DropDownData
                              {
                                  Text = Enum.GetName(typeof (Responses), value),
                                  Value = value
                              });
            }
            return items;
        }
    }
