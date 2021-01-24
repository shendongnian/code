    public void SetupData(MyContext context) 
    {
        var user = new User() { Id = Fixture.TEST_USER1_ID, UserName = Fixture.TEST_USER1_NAME };
        context.Users.Add(user);
        context.SaveChanges();
    }
    
    public class Fixture 
    {
        public const int TEST_USER1_ID = 123;
        public const string TEST_USER!_NAME = "testuser";
    }
