    public class Mapper
    {
        private string name;
        [Display(Name = "MapName")]
        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = nameMap.ContainsKey(value) ? nameMap[value] : value;
                }
            }
        }
        private Dictionary<string, string> nameMap = new Dictionary<string, string>
        {
            {"xyz", "a"},
            {"abc", "123"}
        };
        // Rest of class omitted
    }
