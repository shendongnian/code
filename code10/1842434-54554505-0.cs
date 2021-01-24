    public static class MyClass
    {
        public static User LoadUser(int userId)
        {
            using (var uow = new UnitOfWork())
            {
                DoSomething(uow);
                DoSomethingElse(uow);
                var user = GetUserByDoingAnotherThing(uow);
                return user;
            }
        }
    }
