    using MyStuff;
    
    using A = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
    
    namespace Mytestproj.Tests
    {
        public static class Assert
        {
            public static void AreEqual(object expected, object actual)
            {
                A.AreEqual(expected, actual);
            }
            // my extension
            public static void AreEqual(MyEnum expected, int actual)
            {
                A.AreEqual((int)expected, actual);
            }
    
            public static void IsTrue(bool o)
            {
                A.IsTrue(o);
            }
    
            public static void IsFalse(bool o)
            {
                A.IsFalse(o);
            }
    
            public static void AreNotEqual(object notExpected, object actual)
            {
                A.AreNotEqual(notExpected, actual);
            }
    
            public static void IsNotNull(object o)
            {
                A.IsNotNull(o);
            }
    
            public static void IsNull(object o)
            {
                A.IsNull(o);
            }
        }
    }
