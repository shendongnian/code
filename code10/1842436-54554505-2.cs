    public static class MyClass
    {
        public static Func<IUnitOfWork> CreateUnitOfWork { get; set; }
        public static User LoadUser(int userId)
        {
            using (var uow = CreateUnitOfWork())
            {
                DoSomething(uow);
                DoSomethingElse(uow);
                var user = GetUserByDoingAnotherThing(uow);
                return user;
            }
        }
    }
