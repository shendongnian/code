    [TestFixture]
    public class when_running_bootstrapper
    {
        [Test]
        public void it_should_request_its_view_model()
        {
            TestFactory.PerformRun(b =>
                CollectionAssert.Contains(b.Requested, typeof(SampleViewModel).FullName));
        }
        [Test]
        public void it_should_request_a_window_manager_on_dotnet()
        {
            TestFactory.PerformRun(b => 
                CollectionAssert.Contains(b.Requested, typeof(IWindowManager).FullName));
        }
        [Test]
        public void it_should_release_the_window_manager_once()
        {
            TestFactory.PerformRun(b =>
                Assert.That(b.ReleasesFor<IWindowManager>(), Is.EqualTo(1)));
        }
        [Test]
        public void it_should_release_the_root_view_model_once()
        {
            TestFactory.PerformRun(b =>
                Assert.That(b.ReleasesFor<SampleViewModel>(), Is.EqualTo(1)));
        }
    }
    static class TestFactory
    {
        public static void PerformRun(Action<TestBootStrapper> testLogic)
        {
            var stackTrace = new StackTrace();
            var name = stackTrace.GetFrames().First(x => x.GetMethod().Name.StartsWith("it_should")).GetMethod().Name;
            var tmpDomain = AppDomain.CreateDomain(name,
                AppDomain.CurrentDomain.Evidence,
                AppDomain.CurrentDomain.BaseDirectory,
                AppDomain.CurrentDomain.RelativeSearchPath,
                AppDomain.CurrentDomain.ShadowCopyFiles);
            var proxy = (Wrapper)tmpDomain.CreateInstanceAndUnwrap(typeof (TestFactory).Assembly.FullName, typeof (Wrapper).FullName);
            try
            {
                testLogic(proxy.Bootstrapper);
            }
            finally
            {
                AppDomain.Unload(tmpDomain);
            }
        }
    }
    [Serializable]
    public class Wrapper
        : MarshalByRefObject
    {
        TestBootStrapper _bootstrapper;
        public Wrapper()
        {
            var t = new Thread(() =>
                {
                    var app = new Application();
                    _bootstrapper = new TestBootStrapper(app);
                    app.Run();
                });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }
        public TestBootStrapper Bootstrapper
        {
            get { return _bootstrapper; }
        }
    }
    [Serializable]
    public class TestBootStrapper
        : Bootstrapper<SampleViewModel>
    {
        [NonSerialized]
        readonly Application _application;
        [NonSerialized]
        readonly Dictionary<Type, object> _defaults = new Dictionary<Type, object>
            {
                { typeof(IWindowManager), new WindowManager() }
            };
        readonly Dictionary<string, uint> _releases = new Dictionary<string, uint>();
        readonly List<string> _requested = new List<string>();
        public TestBootStrapper(Application application)
        {
            _application = application;
        }
        protected override object GetInstance(Type service, string key)
        {
            _requested.Add(service.FullName);
            if (_defaults.ContainsKey(service))
                return _defaults[service];
            return new SampleViewModel();
        }
        protected override void ReleaseInstance(object instance)
        {
            var type = instance.GetType();
            var t = (type.GetInterfaces().FirstOrDefault() ?? type).FullName;
            if (!_releases.ContainsKey(t))
                _releases[t] = 1;
            else
                _releases[t] = _releases[t] + 1;
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            throw new NotSupportedException("Not in this test");
        }
        protected override void BuildUp(object instance)
        {
            throw new NotSupportedException("Not in this test");
        }
        protected override void Configure()
        {
            base.Configure();
        }
        protected override void OnExit(object sender, EventArgs e)
        {
            base.OnExit(sender, e);
        }
        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            base.OnStartup(sender, e);
            _application.Shutdown(0);
        }
        protected override IEnumerable<System.Reflection.Assembly> SelectAssemblies()
        {
            return new[] { typeof(TestBootStrapper).Assembly };
        }
        public IEnumerable<string> Requested
        {
            get { return _requested; }
        }
        public uint ReleasesFor<T>()
        {
            if (_releases.ContainsKey(typeof(T).FullName))
                return _releases[typeof (T).FullName];
            return 0u;
        }
    }
    [Serializable]
    public class SampleViewModel
    {
    }
