    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SampleClassLib;
    using System;
    using System.Windows.Forms;
    
    namespace TestNamespace
    {
        [TestClass()]
        public sealed class DivideClassTest
        {
            [AssemblyInitialize()]
            public static void AssemblyInit(TestContext context)
            {
                MessageBox.Show("AssemblyInit " + context.TestName);
            }
    
            [ClassInitialize()]
            public static void ClassInit(TestContext context)
            {
                MessageBox.Show("ClassInit " + context.TestName);
            }
    
            [TestInitialize()]
            public void Initialize()
            {
                MessageBox.Show("TestMethodInit");
            }
    
            [TestCleanup()]
            public void Cleanup()
            {
                MessageBox.Show("TestMethodCleanup");
            }
    
            [ClassCleanup()]
            public static void ClassCleanup()
            {
                MessageBox.Show("ClassCleanup");
            }
    
            [AssemblyCleanup()]
            public static void AssemblyCleanup()
            {
                MessageBox.Show("AssemblyCleanup");
            }
    
            [TestMethod()]
            [ExpectedException(typeof(System.DivideByZeroException))]
            public void DivideMethodTest()
            {
                DivideClass.DivideMethod(0);
            }
        }
    }
