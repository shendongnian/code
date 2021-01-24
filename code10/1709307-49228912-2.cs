    class Quote
    {
        public static Quote Calculate()
        {
            var resultData = DoComputations();
            return new Quote(resultData);
        }
    }
