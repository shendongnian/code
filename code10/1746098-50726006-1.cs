    using System;
    using Microsoft.QualityTools.Testing.Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace FakesExampleTests
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                using (ShimsContext.Create())
                {
                    FakesExample.Fakes.ShimMyStaticClass.GetTextString = (s) =>
                    {
                        return "Go away null reference";
                    };
    
                    Console.WriteLine(FakesExample.MyStaticClass.GetText("foo"));
                }
            }
        }
    }
