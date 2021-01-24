    public static class StudentRepositoryFactory
    {
        public static IStudentRepository InstanciateRepo(bool FromDatabase)
        {
            if (FromDatabase)
            {
                return new DatabaseStudentFactory("ConnectionString To my server");
            }
            else
            {
                return new TestStudentRepository();
            }
        }
    }
