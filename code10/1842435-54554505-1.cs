    public static class MyClass
    {
        public static IKernel Kernel { get; set; }
        public static User LoadUser(int userId)
        {
            using (var uow = Kernel.Get<IUnitOfWork>())
            {
                DoSomething(uow);
                DoSomethingElse(uow);
                var user = GetUserByDoingAnotherThing(uow);
                return user;
            }
        }
    }
