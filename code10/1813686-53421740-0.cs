    using System.IO;
    using System.Collections;
    using System.Collections.Generic;
    
    class nm
    {
        public static void Main()
        {
            var dicdic = new Dictionary<string, Dictionary<string, List<string>>>();
            var subdicdic = new Dictionary<string, List<string>>();
            var p = new List<string>();
            p.Add("bro, you feel me ");
            subdicdic.Add("ll", p);
            dicdic.Add("foo", subdicdic);
        }
    }
