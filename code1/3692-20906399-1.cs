    using System;
    using ConsoleApplication11;
    using Microsoft.QualityTools.Testing.Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace DateTimeTest
    {
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWhatsTheTime()
        {
            
            using(ShimsContext.Create()){
                //Arrange
                System.Fakes.ShimDateTime.NowGet =
                () =>
                { return new DateTime(2010, 1, 1); };
                var myClass = new MyClass();
                
                //Act
                var timeString = myClass.WhatsTheTime();
                //Assert
                Assert.AreEqual("1/1/2010 12:00:00 AM",timeString);
              
            }
        }
    }
    }
  
