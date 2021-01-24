    internal class UserEqualChecker : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            //Code for what makes them equal
            //for instance 
            return x.UserName.Equals(y.UserName);
        }
        //.....
    }
