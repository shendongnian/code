    class Repository
    {
        public static Rep[] Reps = new Rep[6];
        public class Rep
        {
            public string Main {get; set;}
            public string Clean {get; set;}
            public int CurParCount {get; set;}
            public int TotalCount {get; set;}
            public int ParStart {get; set;}
            public int PartialStart {get; set;}
            public double ScrollPos {get; set;}
            public int SelectionStart {get; set;}
            public int SelectionEnd {get; set;}
            public string[] Statuses {get; set;}
        }                                                                      
     }
