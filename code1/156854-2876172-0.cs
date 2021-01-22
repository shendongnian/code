    public class Common
    {
        public const string STARTDATE = "STARTDATE";
        public const string CUSTOMERNAME = "CUSTOMERNAME";
        
        public static string GetMappedValue(string inputVariable)
        {
            string mappedTo = null;
            switch(inputVariable)
            {
                case "abc":
                    mappedTo = SOME_OTHER_CONSTANT_HERE; //map it 
                    break;
                case "xyz":
                    mappedTo = FOO;
                    break;
                //etc etc...
            }
            return mappedTo;
        }
