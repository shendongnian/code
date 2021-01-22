    -- The Test Class--
    namespace _64BitCLTest
    {
        [Guid("BBAA06EF-CA4C-4fe2-97CD-9B1D85ADA656")]
        [ClassInterface(ClassInterfaceType.AutoDual)]
        [ComVisible(true)]
        [ProgId("64BitCLTest.Class1")]
        public class Class1
        {
            public Class1()
            {
                // do nothing
            }
    
            public string Method1()
            {
                return "This is a return string from method 1";
            }
    
            public int Property1
            {
                get {return 777;}
            }
        }
    }
