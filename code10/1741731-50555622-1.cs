    class CarTypes
    {
        private CarTypes(Guid id) 
        {
            Id = id;
        }
        public static CarTypes Sedan { get; } = new CarTypes(Guid.Parse("6f8bdca0-2fb3-4163-884b-b75b1d20a428"));
        public static CarTypes HatchBack { get; } = new CarTypes(Guid.Parse("4ad6432a-ed9d-4947-91a6-78756df51a81"));
        public Guid Id { get; }
    }
