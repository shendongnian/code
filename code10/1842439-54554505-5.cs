    public static class MyClass
    {
        public static Func<IUnitOfWork> CreateUnitOfWork { get; set; }
        public static User LoadUser(int userId)
        {
            using (var uow = CreateUnitOfWork())
            {
                DoSomething(uow);
                var user = uow.UserRepository.GetById(userId);
                return user;
            }
        }
    }
