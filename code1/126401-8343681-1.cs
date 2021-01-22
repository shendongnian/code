     [Flags]
    public enum SourceEnum
    {
        SA = 0x08,
        SB = 0x20,
        SC = 0x10,
        SAB = SA | SB,
        SABC = SA | SB | SC
    }
    [Flags]
    public enum DestEnum
    {
        DA = 0x04,
        DB = 0x80,
        DC = 0x01,
        DAB = DA | DB
    }
    public static class ExtensionTests
    {
       
        public static SourceEnum ToSourceEnum(this DestEnum destEnum)
        {
            SourceEnum toSourceEnum=0x0;
            if ((destEnum & DestEnum.DA) == DestEnum.DA)
                toSourceEnum |= SourceEnum.SA;
            if ((destEnum & DestEnum.DB) == DestEnum.DB)
                toSourceEnum |= SourceEnum.SB;
            if ((destEnum & DestEnum.DC) == DestEnum.DC)
                toSourceEnum |= SourceEnum.SC;
            return toSourceEnum;
        }
        public static DestEnum ToDestEnum(this SourceEnum sourceEnum)
        {
            DestEnum toDestEnum=0;
            if ((sourceEnum & SourceEnum.SA) == SourceEnum.SA)
                toDestEnum = toDestEnum | DestEnum.DA;
            if ((sourceEnum & SourceEnum.SB) == SourceEnum.SB)
                toDestEnum = toDestEnum | DestEnum.DB;
            if ((sourceEnum & SourceEnum.SC) == SourceEnum.SC)
                toDestEnum = toDestEnum | DestEnum.DC;
            return toDestEnum;
        }
    }
    /// <summary>
    ///This is a test class for ExtensionMethodsTest and is intended
    ///to contain all ExtensionMethodsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExtensionMethodsTest
    {
        #region Sources
        [TestMethod]
        public void ExtensionMethodsTest_SourceEnum_SA_inverts()
        {
            //then you code goes like this...
            SourceEnum sourceEnum = SourceEnum.SA;
            Assert.AreEqual(SourceEnum.SA, sourceEnum.ToDestEnum().ToSourceEnum(), "");
            //and vice-versa...
        }
        [TestMethod]
        public void ExtensionMethodsTest_SourceEnum_SAB_inverts()
        {
            //then you code goes like this...
            SourceEnum sourceEnum = SourceEnum.SAB;
            Assert.AreEqual(SourceEnum.SAB, sourceEnum.ToDestEnum().ToSourceEnum());
            //and vice-versa...
        }
        [TestMethod]
        public void ExtensionMethodsTest_SourceEnum_SABC_inverts()
        {
            //then you code goes like this...
            SourceEnum sourceEnum = SourceEnum.SABC;
            Assert.AreEqual(SourceEnum.SABC, sourceEnum.ToDestEnum().ToSourceEnum());
            //and vice-versa...
        }
        [TestMethod]
        public void ExtensionMethodsTest_SourceEnum_SA_Union_SC_inverts()
        {
            //then you code goes like this...
            SourceEnum sourceEnum = SourceEnum.SA | SourceEnum.SC;
            Assert.AreEqual(SourceEnum.SA | SourceEnum.SC, sourceEnum.ToDestEnum().ToSourceEnum());
            //and vice-versa...
        }
        #endregion
        #region Source To Destination
        [TestMethod]
        public void ExtensionMethodsTest_SourceEnum_SA_returns_DestEnum_DA()
        {
            Assert.IsTrue(DestEnum.DA == SourceEnum.SA.ToDestEnum());
        }
        [TestMethod]
        public void ExtensionMethodsTest_SourceEnum_SAB_returns_DestEnum_DAB()
        {
            Assert.IsTrue(DestEnum.DAB == SourceEnum.SAB.ToDestEnum());
        }
        [TestMethod]
        public void ExtensionMethodsTest_SourceEnum_SA_SC_returns_DestEnum_DA_DC()
        {
            Assert.IsTrue((DestEnum.DA | DestEnum.DC) == (SourceEnum.SA | SourceEnum.SC ).ToDestEnum());
        }
        #endregion
        #region Destination to Source
         [TestMethod]
        public void ExtensionMethodsTest_DestEnum_SA_returns_SourceEnum_DA()
        {
            Assert.IsTrue(SourceEnum.SA == DestEnum.DA.ToSourceEnum());
        }
         [TestMethod]
        public void ExtensionMethodsTest_DestEnum_SAB_returns_SourceEnum_DAB()
        {
            Assert.IsTrue(SourceEnum.SAB == DestEnum.DAB.ToSourceEnum());
        }
         [TestMethod]
        public void ExtensionMethodsTest_DestEnum_SABC_returns_SourceEnum_DAB_DC()
        {
            Assert.IsTrue(SourceEnum.SABC == (DestEnum.DAB | DestEnum.DC ).ToSourceEnum());
        }
        #endregion
    }
