    using System;
    class Test {
        private DateTime modifiedOn;
        public DateTime ModifiedOn {     
            get { return modifiedOn; }
            private set { modifiedOn = value; }
        }
    }
    static class Program {
        static void Main() {
            Test p = new Test();
            typeof(Test).GetProperty("ModifiedOn").SetValue(
                p, DateTime.Today, null);
            Console.WriteLine(p.ModifiedOn);
        }
    }
