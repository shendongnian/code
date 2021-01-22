    interface IFriend { }
    class Friend : IFriend
    {
        public static IFriend New() { return new Friend(); }
        private Friend() { }
        private void CallTheBody() 
        {  
            var body = new Body();
            body.ItsMeYourFriend(this);
        }
    }
    class Body
    { 
        public void ItsMeYourFriend(Friend onlyAccess) { }
    }
