        public void ImportantMethodThatMustBeThreadSafe()
        {
            using (ImportantTransaction transaction = CreateTransaction())
            {
                transaction.Facade.ImportantMethodThatMustBeThreadSafe();
            }
        }
