    [TestClass]
    public class UnitTest19
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mapper.Initialize(expression => expression.AddProfile(new MyProfile()));
            var queryableOfObjectA = new List<objectA>
            {
                new objectA
                {
                    myNullableInt = 10
                }
            };
            
            var result = queryableOfObjectA.AsQueryable().ProjectTo<objectB>(new { _injectedInt = (int?)1 });
            var resultingValue = result.FirstOrDefault()?.myNullableInt;
            Assert.AreEqual(100, resultingValue);
        }
    }
    
    public class MyProfile : Profile
    {
        public MyProfile()
        {
            int? _injectedInt = null;
            CreateMap<objectA, objectB>()
                .ForMember(e => e.myNullableInt, x => x.MapFrom(s => _injectedInt.HasValue ? 100 : 0));
        }
    }
    public class objectA
    {
        public int myNullableInt { get; set; }
    }
    public class objectB
    {
        public int myNullableInt { get; set; }
    }
