	public class StudentsMappingProfile : Profile
	{
		public StudentsMappingProfile()
		{
			CreateMap<StudentValueObject, StudentDetailsViewModel>()
				.ForMember(viewModel => viewModel.listQualificationViewModel, conf => conf.MapFrom(value => value.listStudentQualificationValueObject));
			CreateMap<StudentQualificationValueObject, QualificationViewModel>();
		}
	}
	public class Program
	{
		public static void Main()
		{
			var config = new MapperConfiguration(cfg => cfg.AddProfile<StudentsMappingProfile>());
			var mapper = config.CreateMapper();
			var source = new StudentValueObject { ID = 73, FirstName = "Hello", listStudentQualificationValueObject = new List<StudentQualificationValueObject> { new StudentQualificationValueObject { ID = 42, StudentID = 17, ExaminationPassed = "World" } } };
			var destination = mapper.Map<StudentDetailsViewModel>(source);
			Console.ReadKey();
		}
	}
