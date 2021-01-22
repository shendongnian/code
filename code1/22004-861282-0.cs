    /// <summary>
    /// HTTP session mockup.
    /// </summary>
    internal sealed class HttpSessionMock : HttpSessionStateBase
    {
        private readonly Dictionary<string, object> objects = new Dictionary<string, object>();
    
        public override object this[string name]
        {
            get { return (objects.ContainsKey(name)) ? objects[name] : null; }
            set { objects[name] = value; }
        }
    }
    /// <summary>
    /// Base class for all controller tests.
    /// </summary>
    public class ControllerTestSuiteBase : TestSuiteBase
    {
        private readonly HttpSessionMock sessionMock = new HttpSessionMock();
    
        protected readonly Mock<HttpContextBase> Context = new Mock<HttpContextBase>();
        protected readonly Mock<HttpSessionStateBase> Session = new Mock<HttpSessionStateBase>();
    
        public ControllerTestSuiteBase()
            : base()
        {
            Context.Expect(ctx => ctx.Session).Returns(sessionMock);
        }
    }
