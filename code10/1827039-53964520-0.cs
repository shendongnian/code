    public interface ICustomService { }
    public class CustomServiceOne : ICustomService { }
    public class CustomServiceTwo : ICustomService { }
    public class CustomServiceThree : ICustomService { }
    public interface ICustomServiceFactory
    {
        ICustomService Create(string input);
    }
