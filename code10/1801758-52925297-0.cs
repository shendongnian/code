    namespace SampleApp
    {
        class SampleProgram
        {
            static void Main(string[] args)
            {
                User User = new User() { Id = 1 };
                var genericAttribute = (User as GenericAttributes<int>);
                genericAttribute.Id = 2;
                var genericAttributeId = genericAttribute.Id;
                var classId = User.Id;
            }
        }
        public class GenericAttributes<T>
        {
            public T Id { get; set; }
        }
        public class User : GenericAttributes<int>
        {
            public new int Id { get; set; }
        }
    }
