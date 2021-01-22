    //enum DocInfos { DocName, DocNumber, DocVersion};
    public class DocInfos
    {
        public static int DocName = 0;
        public static int DocNumer = 1;
        public static int DocVersion = 2;
    }
...      
       
                Doc = new string[DocInfos.DocVersion];
                // Treffer
                Doc[DocInfos.DocName] = TrimB(HTMLLines[lineCounter + 2])
