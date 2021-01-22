    [TestFixture]
    public class When_Presenter_Loads
    {
        private MockRepository mockRepository;
        private ITableRepository tableRepository;
        private IClass clazz;
        private Dictionary<string, Type> properties;
        private IClassGenerationView view;
        private ClassGenerationPresenter presenter;
        [SetUp]
        public void Setup()
        {
            mockRepository =new MockRepository();
            properties = new Dictionary<string, Type>();
            clazz = mockRepository.DynamicMock<IClass>();
            view = mockRepository.DynamicMock<IClassGenerationView>();
            tableRepository = mockRepository.Stub<ITableRepository>();
            
        }
        [Test]
        public void View_Should_Display_Class_Properties()
        {
            using(mockRepository.Record())
            {
                SetupResult.For(clazz.Properties).Return(properties);
                view.ClassProperties = properties;
            }
            using(mockRepository.Playback())
            {
                presenter = new ClassGenerationPresenter(view, clazz, tableRepository);
                presenter.Load();
            }
        }
        [Test]
        public void View_Should_Display_Class_Name_As_A_Table_Name()
        {
            using (mockRepository.Record())
            {
                SetupResult.For(clazz.Name).Return("ClassName");
                view.TableName = "ClassName";
            }
            using (mockRepository.Playback())
            {
                presenter = new ClassGenerationPresenter(view, clazz, tableRepository);
                presenter.Load();
            }
        }
        [Test]
        public void View_Should_Display_SQL_Data_Types()
        {
            List<string> dataTypes = new List<string>();
            using(mockRepository.Record())
            {
                SetupResult.For(tableRepository.GetDataTypes()).Return(dataTypes);
                view.DataTypes = dataTypes;
            }
            using(mockRepository.Playback())
            {
                presenter = new ClassGenerationPresenter(view, clazz, tableRepository);
                presenter.Load();
            }
        }
        [Test]
        public void View_Should_Show_Table()
        {
            using (mockRepository.Record())
            {
                SetupResult.For(clazz.Name).Return("ClassName");
                view.Table = null;
                LastCall.IgnoreArguments();
            }
            using (mockRepository.Playback())
            {
                presenter = new ClassGenerationPresenter(view, clazz, tableRepository);
                presenter.Load();
            }
        }
    }
