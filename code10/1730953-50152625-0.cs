    public class Webpage
    {
        public int getVisitCount()
        {
            return DateTime.Now.Second * 2;
        }
        public static List<Webpage> Sort(ArrayList AL)
        {
            var list = AL.Cast<Webpage>().ToList();
            var ordered = list.OrderBy(x => x.getVisitCount());
            return list;
        }
    }
