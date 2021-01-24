    public class TestBase
    {
        public TestContext TestContext { get; set; }
    
        public static int Colegio { get; set; }
    
        [AssemblyInitialize]
        public static void ClassInitialize(TestContext TestContext)
        {
            Colegio = int.Parse(TestContext.Properties["colegio"].ToString()); // colegio is equal 7 in here
        }
    
        public TestBase()
        {
            SeleniumHelper = new HelperSelenium(Colegio, WebDriverSelector.ObtenerWebDriver());
            DiccionarioCompartido = new Dictionary<string, string>();
        }
