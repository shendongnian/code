    class Program
    {
        [Flags]
        public enum CheckType
        {
            Form = 1,
            QueryString = 2,
            TempData = 4,
        }
        private static bool DoSomething(IEnumerable cln)
        {
            Console.WriteLine("DoSomething");
            return true;
        }
        private static bool DoSomethingElse(IEnumerable cln)
        {
            Console.WriteLine("DoSomethingElse");
            return true;
        }
        private static bool DoWhatever(IEnumerable cln)
        {
            Console.WriteLine("DoWhatever");
            return true;
        }
        static void Main(string[] args)
        {
            var theCheckType = CheckType.QueryString | CheckType.TempData;
            var checkTypeValues = Enum.GetValues(typeof(CheckType));
            foreach (CheckType value in checkTypeValues)
            {
                if ((theCheckType & value) == value)
                {
                    switch (value)
                    {
                        case CheckType.Form:
                            DoSomething(null);
                            break;
                        case CheckType.QueryString:
                            DoSomethingElse(null);
                            break;
                        case CheckType.TempData:
                            DoWhatever(null);
                            break;
                    }
                }
            }
        }
    }
