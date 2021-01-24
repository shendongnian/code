    public class Service
    {
        public int MethodA(int a)
        {
            DatabaseThinger.SaveToDB(a);
            if (validate())
            {
                return a * 5;
            }
            else 
            {
                return 0;
            }
        }
        private IDatabaseThinger DatabaseThinger;
        public Service(IDatabaseThinger databaseThinger)
        {
            DatabaseThinger = databaseThinger;
        }
    }
