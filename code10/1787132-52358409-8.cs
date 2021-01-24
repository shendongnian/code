    using static MyNamepace.UnitManager;
    ...
    class Other
    {
        public void DoSomething() 
        {
            // We don't have now put it as UnitManager.Player1 
            string name1 = Player1.Name;
            ...  
        }
    }
