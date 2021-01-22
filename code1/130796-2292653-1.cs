    class Repository
    {
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
        public const int RepCount = 6;
        public static Rep[] Reps = new Rep[RepCount];
        public static string Name
        {
            get
            { 
                if (MainWindow.repnum == 0)
                  return "Main Text";
                return "Repository " + MainWindow.repnum;
            }
        }
        public static string GetStatus(int repIndex, int statIndex)
        { rep[repIndex].status[statIndex]; }
    }
