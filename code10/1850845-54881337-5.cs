    namespace you.company
    {
      public static CommandExtensions{
        public static Account GetAccountFrom(this CreateUserAccountCommand command)
        {
            return new Account
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
            };
        }
    }
