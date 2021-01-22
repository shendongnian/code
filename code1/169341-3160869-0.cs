    public class TestInterfaceAttribute : Attribute { }
    public interface IMyInjectableService { }
    [TestInterface]
    public class TestService : IMyInjectableService { }
    public class RealService : IMyInjectableService { }
