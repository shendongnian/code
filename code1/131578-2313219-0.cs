      public interface INumbers
        {
            int GetNumber(int arg);
        }
        public class StaticNumber : INumbers
        {
            public int GetNumber(int arg)
            {
                return 1;
            }
        }
        public void DoStuff(INumbers num)
        {
            int i = 42;
            while ((i = num.GetNumber(i)) != 0)
            {
                ;
            }
        }
