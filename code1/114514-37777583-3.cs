    public static class Requires {
        [ContractAbbreviator] 
        public static void NotNull(object obj) {  
            Contract.Requires<ArgumentNullException>(obj != null);
        }
        [ContractAbbreviator]
        public static void NotNullOrEmpty(string str) {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(str));
        }
        [ContractAbbreviator]
        public static void NotNullOrEmpty(IEnumerable<T> sequence) {
            Contract.Requires<ArgumentNullException>(sequence != null);
            Contract.Requires<ArgumentNullException>(sequence.Any());
        }
    }
    public static class Ensures {
        [ContractAbbreviator]
        public static void NotNull(){
            Contract.Ensures(Contract.Result<object>() != null);
        }
    }
