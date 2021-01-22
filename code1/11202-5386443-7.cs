    using System;
    using MbUnit.Framework;
    namespace IndexOfNthTest
    {
        [TestFixture]
        public class Tests
        {
            //has 4 instances of the 
            private const string Input = "TestTest";
            private const string Token = "Test";
            /* Test for 0th index */
            [Test]
            public void TestZero()
            {
                Assert.Throws<NotSupportedException>(
                    () => Input.IndexOfNth(Token, 0, 0));
            }
            /* Test the two standard cases (1st and 2nd) */
            [Test]
            public void TestFirst()
            {
                Assert.AreEqual(0, Input.IndexOfNth("Test", 0, 1));
            }
            [Test]
            public void TestSecond()
            {
                Assert.AreEqual(4, Input.IndexOfNth("Test", 0, 2));
            }
            /* Test the 'out of bounds' case */
            [Test]
            public void TestThird()
            {
                Assert.AreEqual(-1, Input.IndexOfNth("Test", 0, 3));
            }
            /* Test the offset case (in and out of bounds) */
            [Test]
            public void TestFirstWithOneOffset()
            {
                Assert.AreEqual(4, Input.IndexOfNth("Test", 4, 1));
            }
            [Test]
            public void TestFirstWithTwoOffsets()
            {
                Assert.AreEqual(-1, Input.IndexOfNth("Test", 8, 1));
            }
        }
    }
