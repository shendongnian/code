    public static class AutoCompleteFactory
    {
        public static IAutoComplete CreateFor<T>()
        {
            // build up and return an IAutoComplete implementation based on T which
            // could be Customer, Item, BranchOffice class.
        }
    }
