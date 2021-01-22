    using System;
    using SmalltalkBooleanExtensionMethods;
    using NUnit.Framework;
    
    namespace SmalltalkBooleanExtensionMethodsTest
    {
        [TestFixture]
        public class SBEMTest
        {
            int i;
            bool itWorks;
    
            [SetUp]
            public void Init()
            {
    
                i = 0;
                itWorks = false;
            }
    
            [Test()]
            public void TestifTrue()
            {
    
                itWorks = (true.ifTrue(() => true));
                Assert.IsTrue(itWorks);
            }
            [Test()]
            public void TestifFalse()
            {
                itWorks = (false.ifFalse(() => true));
                Assert.IsTrue(itWorks);
            }
    
            [Test()]
            public void TestifTrueifFalse()
            {
                itWorks = false.ifTrueifFalse(() => false, () => true);
                Assert.IsTrue(itWorks);
                itWorks = false;
                itWorks = true.ifTrueifFalse(() => true, () => false);
                Assert.IsTrue(itWorks);
            }
    
            [Test()]
            public void TestTimesRepeat()
            {
                (5).timesRepeat(() => i = i + 1);
                Assert.AreEqual(i, 5);
            }
    
            [Test()]
            public void TestVoidMethodIfTrue()
            {
    
                true.ifTrue(() => SetItWorksBooleanToTrue());
                Assert.IsTrue(itWorks);
            }
    
            [Test()]
            public void TestVoidMethodIfFalse()
            {
    
                false.ifFalse(() => SetItWorksBooleanToTrue());
                Assert.IsTrue(itWorks);
            }
    
            public void TestVoidMethodIfTrueIfFalse()
            {
                true.ifTrueifFalse(() => SetItWorksBooleanToTrue(), () => SetItWorksBooleanToFalse());
                false.ifTrueifFalse(() => SetItWorksBooleanToFalse(), () => SetItWorksBooleanToTrue());
                Assert.IsTrue(itWorks);
    
            }
    
            public void TestVoidMethodTimesRepeat()
            {
                (5).timesRepeat(() => AddOneToi());
                Assert.AreEqual(i, 5);
            }
    
            public void SetItWorksBooleanToTrue()
            {
                itWorks = true;
            }
    
            public void SetItWorksBooleanToFalse()
            {
                itWorks = false;
            }
    
            public void AddOneToi()
            {
                i = i + 1;
            }
        }
    }
