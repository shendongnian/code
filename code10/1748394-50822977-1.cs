    public class InternalClassObject
    {
        public string Name { get; set; }
        public List<string> ParameterNameList { get; set; }
        public List<string> ParameterList { get; set; }
        public InternalClassObject(string iName,List<string> iParameterNameList, List<string> iParameterList)
        {
            Name = iName;
            ParameterNameList = iParameterNameList;
            ParameterList = iParameterList;
        }
    }
