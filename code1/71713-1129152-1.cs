    public class HelloWorld
    {
        public CultureInfo CultureInfo { get; private set; }
        public HelloWorld()
        {
            CultureInfo = CultureInfo.CurrentCulture;
        }
        public HelloWorld(string culture)
        {
            CultureInfo = CultureInfo.GetCultureInfo(culture);
        }
        public string SayHelloWorld()
        {
            return Resources.ResourceManager.GetString("HelloWorld", CultureInfo);
        }
    }
    [TestFixture]
    public class HelloWorldFixture
    {
        HelloWorld helloWorld;
        [Test]
        public void Ctor_SetsCultureInfo_ToCurrentCultureForParameterlessCtor()
        {
            helloWorld = new HelloWorld();
            Assert.AreEqual(helloWorld.CultureInfo, CultureInfo.CurrentCulture,
                "Expected CultureInfo to be set as CurrentCulture");
        }
        [Test]
        public void Ctor_SetsCultureInfo_ToAustralianCulture()
        {
            helloWorld = new HelloWorld("en-AU");
            Assert.AreEqual(helloWorld.CultureInfo.Name, "en-AU",
                "Expected CultureInfo to be set to Australian culture");
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_ThrowsException_InvalidCultureName()
        {
            helloWorld = new HelloWorld("Bogus");
        }
        [Test]
        public void SayHelloWorld_ReturnsFallbackResource_OnUndefinedResource()
        {
            helloWorld = new HelloWorld("en-JM");
            string result = helloWorld.SayHelloWorld();
            Assert.AreEqual("Hello, World.", result, "Expected fallback resource string to be used");
        }
        [Test]
        public void SayHelloWorld_ReturnsAustralianResource_OnAustralianResource()
        {
            helloWorld = new HelloWorld("en-AU");
            string result = helloWorld.SayHelloWorld();
            Assert.AreEqual("G'Day, World.", result, "Expected australian resource string to be used");
        }
    }
