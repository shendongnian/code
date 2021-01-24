    class Program
    {
        static void Main(string[] args)
        {
            List<ObjA> objAs = new List<ObjA>();
            List<ObjB> objBs = new List<ObjB>();
            var query = (from a in objAs
                         join b in objBs on a.ID equals b.ID
                         select new ObjView()
                         {
                             ObjA = new ObjA()
                             {
                                 Item1 = a.Item1,
                                 Item2 = a.Item2
                             },
                             ObjB = new ObjB()
                             {
                                 Item1 = b.Item1,
                                 Item2 = b.Item2
                             }
                         });
        }
    }
    public class ObjA
    {
        public int ID { get; set; }
        public Object Item1 { get; set; }
        public Object Item2 { get; set; }
    }
    public class ObjB
    {
        public int ID { get; set; }
        public Object Item1 { get; set; }
        public Object Item2 { get; set; }
    }
    public class ObjView
    {
        public ObjA ObjA { get; set; }
        public ObjB ObjB { get; set; }
    }
