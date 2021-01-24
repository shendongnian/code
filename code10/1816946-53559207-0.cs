     class Program
    {
        static void Main(string[] args)
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = mapperConfiguration.CreateMapper();
            var fullStudent = new FullStudent()
            {
                Name = "Mike",
                Surname = "Magoo",
                BirthDate = DateTime.Now,
                StudentNumber = 1,
                Grade = "Freshman",
                PhoneNumber = "555-5555"
            };
            var limitedStudent = mapper.Map<StudentDTO>(fullStudent);
            Console.ReadKey();
        }
    }
    public class FullStudent
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int StudentNumber { get; set; }
        public string Grade { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class StudentDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int StudentNumber { get; set; }
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FullStudent, StudentDTO>();
        }
    }
