    using TotallyDifferentNameSpace.Enums;
    namespace EnumEx
    {
        class Program
        {
            static void Main(string[] args)
            {
                CarType car = CarType.Audi;
                PetrolType pType = PetrolType.Diesel;
            }
        }
        public enum CarType
        {
            Volkswagen,
            Audi,
            Toyota,
            Ford,
            Porsche,
            Lada
        }
    }
    namespace TotallyDifferentNameSpace.Enums
    {
        public enum PetrolType
        {
            Gasoline,
            Diesel
        }
    }
