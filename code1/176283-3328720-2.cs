       [TestClass]
       class MyClass {
          [TestMethod]
          public void MyTest() {
             string myString = "foo";
             if (myString == "bar")
                Console.WriteLine("w00t");
          }
       }
