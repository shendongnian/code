    [TestClass]
    public class GetCSName
    {
        private string GetCSCompilerName(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            var compiler = new CSharpCodeProvider();
            var typeRef = new CodeTypeReference(type);
            return compiler.GetTypeOutput(typeRef);
        }
        [TestMethod]
        public void TestMethod1()
        {
            List<Type> typesToTest = new List<Type>();
            typesToTest.Add(typeof(string));
            typesToTest.Add(typeof(string[]));
            typesToTest.Add(typeof(object[]));
            typesToTest.Add(typeof(bool[]));
            typesToTest.Add(typeof(string));
            typesToTest.Add(typeof(object));
            typesToTest.Add(typeof(int));
            typesToTest.Add(typeof(double));
            typesToTest.Add(typeof(float));
            typesToTest.Add(typeof(bool));
            typesToTest.Add(typeof(char));
            typesToTest.Add(typeof(decimal));
            typesToTest.Add(typeof(decimal?[]));
            typesToTest.Add(typeof(decimal?[][]));
            typesToTest.Add(typeof(Int64));
            typesToTest.Add(typeof(Guid));
            typesToTest.Add(typeof(int?));
            typesToTest.Add(typeof(double?));
            typesToTest.Add(typeof(float?));
            typesToTest.Add(typeof(bool?));
            typesToTest.Add(typeof(char?));
            typesToTest.Add(typeof(decimal?));
            typesToTest.Add(typeof(Int64?));
            typesToTest.Add(typeof(Guid?));
            typesToTest.Add(typeof(List<string>));
            typesToTest.Add(typeof(Dictionary<string, Guid>));
            typesToTest.Add(typeof(Dictionary<string, Guid>[]));
            typesToTest.Add(typeof(Dictionary<string, Guid?>));
            typesToTest.Add(typeof(Dictionary<string, Dictionary<string, Guid?>>));
            typesToTest.Add(typeof(Dictionary<string, Dictionary<string, Guid?>>[]));
            typesToTest.Add(typeof(Dictionary<string, Dictionary<string, Guid?>>[][]));
            typesToTest.Add(typeof(int[]));
            typesToTest.Add(typeof(int[][]));
            typesToTest.Add(typeof(int[][][]));
            typesToTest.Add(typeof(int[][][][]));
            typesToTest.Add(typeof(int[][][][][]));
            typesToTest.Add(typeof(TestClass));
            typesToTest.Add(typeof(List<TestClass>));
            typesToTest.Add(typeof(Dictionary<TestClass, TestClass>));
            typesToTest.Add(typeof(Dictionary<string, TestClass>));
            typesToTest.Add(typeof(List<Dictionary<string, TestClass>>));
            typesToTest.Add(typeof(List<Dictionary<string, GenericTestClass<string>>>));
            typesToTest.Add(typeof(GenericTestClass<string>.SecondSubType<decimal>));
            typesToTest.Add(typeof(GenericTestClass<string>.SecondSubType));
            typesToTest.Add(typeof(GenericTestClass<string, int>.SecondSubType));
            typesToTest.Add(typeof(GenericTestClass<string, Dictionary<string,int>>.SecondSubType<string>));
            typesToTest.Add(typeof(GenericTestClass<string, Dictionary<string, int>>.SecondSubType<GenericTestClass<string, Dictionary<string, int>>>));
            foreach (var t in typesToTest)
            {
                if (GetCSCompilerName(t) != t.GetCSTypeName())
                {
                    Console.WriteLine($"FullName:\r\n{t.FullName}");
                    Console.WriteLine("C " + GetCSCompilerName(t));
                    Console.WriteLine("R " + t.GetCSTypeName());
                    Console.WriteLine("Equal: " + (GetCSCompilerName(t) == t.GetCSTypeName()));
                    Console.WriteLine();
                    Assert.Fail($"From CSharpCodeProvider '{GetCSCompilerName(t)}' is not equal to {t.GetCSTypeName()}");
                }
                else
                {
                    Console.WriteLine($"Passed: {t.GetCSTypeName()}");
                    //ignore because of equal.
                }
            }
        }
        public class TestClass
        {
            
        }
        public class GenericTestClass<T>
        {
            public class SecondSubType
            {
                
            }
            public class SecondSubType<T2>
            {
            }
        }
        public class GenericTestClass<T1,T2>
        {
            public class SecondSubType
            {
            }
            public class SecondSubType<T2>
            {
            }
        }
    }
