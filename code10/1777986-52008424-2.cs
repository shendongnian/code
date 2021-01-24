    public class MyModelServicesTest
    {
       private readonly Mapper _mapper;
    
       public MyModelServicesTest()
       {
          _mapper = new Mapper(new MapperConfiguration(cfg => 
               cfg.AddProfile(new MappingProfile())));
       }
    
       [Fact]
       public async Task MyUnitTestMethod()
       {
           var sut = new SomeController(_mapper, _mockSomeRepository.Object);
       }
    }
