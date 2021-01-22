    class MyClass : IYer, INer
    {
        //compiles OK
        void IYer.Hello()
        {
            throw new NotImplementedException();
        }
    
        //error CS0106: The modifier 'public' is not valid for this item
        public void INer.Hello()
        {
            throw new NotImplementedException();
        }
    }
