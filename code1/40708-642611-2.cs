    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Next enum of A = {0}", eRatEnumHelper.GetNextEnumValueOf(eRat.A));
            Console.WriteLine("Next enum of B = {0}", eRatEnumHelper.GetNextEnumValueOf(eRat.B));
            Console.WriteLine("Next enum of C = {0}", eRatEnumHelper.GetNextEnumValueOf(eRat.C));
        }
    }
    public enum eRat { A = 0, B = 3, C = 5, D = 8 };
    public class eRatEnumHelper
    {
        public static eRat GetNextEnumValueOf(eRat value)
        {
            return (from eRat val in Enum.GetValues(typeof (eRat)) 
                    where val > value 
                    orderby val 
                    select val).DefaultIfEmpty().First();
        }
    }
