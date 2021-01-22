    public class ClassUnderTest
    {
        private ProviderClass provider { get; set; }
        public ClassUnderTest( ProviderClass provider )
        {
            this.Provider = provider;
        }
        public int DoOperation()
        {
            return this.Provider.ProviderOperation();
        }
    }
    public class ProviderClass
    {
        private int value = 42;
        public ProviderClass()
        {
        }
        public virtual int ProviderOperation()
        {
            return this.value;
        }
    }
    [TestMethod]
    public void DoOperationTest()
    {
         ProviderClass mockProvider = MockRepository.GenerateMock<ProviderClass>();
         mockProvider.Expect( mp => mp.ProviderOperation() ).Return( -1 );
         ClassUnderTest target = new ClassUnderTest( mockProvider );
         int expectedValue = -1;
         int value = target.DoOperation();
         Assert.AreEqual( expectedValue, value );
         mockProvider.VerifyAllExpectations();
    }
