        public class ObjectA
        {
            public ObjectA()
            {
            }
            public bool status { get; set; }
        }
        public class ClassSample
        {
            public ObjectA MethodA()
            {
                var objectA = new ObjectA();
                // do somethings with objectA
                objectA.status = true;
                return MethodB(objectA);
            }
            public ObjectA MethodB(ObjectA objectA)
            {
                // do somethings
                return objectA;
            }
        }
        [TestMethod]
        public void TestClassSample()
        {
            var mock = new Mock<ClassSample>();
            mock.Setup(p => p.MethodB(It.Is<ObjectA>(q => q.status == true))).Verifiable();
            var result = mock.Object.MethodA();
            mock.Verify();
        }
