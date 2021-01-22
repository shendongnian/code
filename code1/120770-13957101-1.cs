    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
        [TestClass]
        public class StringIndexTest
        {
            [TestMethod]
            public void AddAndSearchValues()
            {
                var si = new StringIndex();
                si.Add("abcdef", "1");
                si.Add("abcdeff", "2");
                si.Add("abcdeffg", "3");
                si.Add("bcdef", "4");
                si.Add("bcdefg", "5");
                si.Add("cdefg", "6");
                si.Add("cdefgh", "7");
                var output = si.GetValuesByPrefixFlattened("abc");
                Assert.IsTrue(output.Contains("1") && output.Contains("2") && output.Contains("3"));
            }
            [TestMethod]
            public void RemoveAndSearch()
            {
                var si = new StringIndex();
                si.Add("abcdef", "1");
                si.Add("abcdeff", "2");
                si.Add("abcdeffg", "3");
                si.Add("bcdef", "4");
                si.Add("bcdefg", "5");
                si.Add("cdefg", "6");
                si.Add("cdefgh", "7");
                si.Remove("abcdef", "1");
                var output = si.GetValuesByPrefixFlattened("abc");
                Assert.IsTrue(!output.Contains("1") && output.Contains("2") && output.Contains("3"));
            }
            [TestMethod]
            public void Clear()
            {
                var si = new StringIndex();
                si.Add("abcdef", "1");
                si.Add("abcdeff", "2");
                si.Add("abcdeffg", "3");
                si.Add("bcdef", "4");
                si.Add("bcdefg", "5");
                si.Add("cdefg", "6");
                si.Add("cdefgh", "7");
                si.Clear();
                var output = si.GetValuesByPrefix("abc");
                Assert.IsTrue(output.Count == 0);
            }
            [TestMethod]
            public void AddAndSearchValuesCount()
            {
                var si = new StringIndex();
                si.Add("abcdef", "1");
                si.Add("abcdeff", "2");
                si.Add("abcdeffg", "3");
                si.Add("bcdef", "4");
                si.Add("bcdefg", "5");
                si.Add("cdefg", "6");
                si.Add("cdefgh", "7");
                si.Remove("cdefgh", "7");
                var output1 = si.GetValuesByPrefixCount("abc");
                var output2 = si.GetValuesByPrefixCount("b");
                var output3 = si.GetValuesByPrefixCount("bc");
                var output4 = si.GetValuesByPrefixCount("ca");
                Assert.IsTrue(output1 == 3 && output2 == 2 && output3 == 2 && output4 == 0);
            }
        }
