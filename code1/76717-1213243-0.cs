    class test
    {
        protected string listName;
    
        protected void getAllItems() 
        {
            return getAllItems(listName);
        }
    }
    
    class test2 : test
    {
        public test2()
        {
            base.listName = "MyUniqueList";
        }
    }
