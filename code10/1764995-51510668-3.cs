     namespace MsTest
      {
          [TestClass]
          public Class TestDataBase 
          {
               [TestMethod()]
               public void SendTest()
               {
                 Mock<ITest> smtpClient = new Mock<ITest>();
                 var DataBase = new DataBase(smtpClient.Object);
                 bool save = DataBase.SaveData(New Data());
                 Assert.IsTrue(save);
            }
          }
      }
