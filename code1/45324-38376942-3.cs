    public class GenHlp_PropBrowser
    {
        public static List<string> PropNamesOfClass(object anObj)
        {
            return anObj == null ? null : PropNamesOfType(anObj.GetType());
        }
        public static List<String> PropNamesOfType(System.Type aTyp)
        {
            List<string> retLst = new List<string>();
            foreach ( var p in aTyp.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance) )
            {
                retLst.Add(p.Name);
            }
            return retLst;
        }
    }
