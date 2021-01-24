    public static class MyClass
    {
        public static IKernel Kernel { get; set; }
        public static User LoadUser(int userId)
        {
            using (var uow = Kernel.Get<IUnitOfWork>())
            {
                DoSomething(uow);
                var user = uow.UserRepository.GetById(userId);
                return user;
            }
        }
    }
