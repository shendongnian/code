    public static class MyClass
    {
        public static User LoadUser(int userId)
        {
            using (var uow = new UnitOfWork())
            {
                DoSomething(uow);
                var user = uow.UserRepository.GetById(userId);
                return user;
            }
        }
    }
