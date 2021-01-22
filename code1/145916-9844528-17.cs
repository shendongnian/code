    // http://www.wtfpl.net
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using mattmc3.Common.Collections.Generic;
    namespace mattmc3.Tests.Common.Collections.Generic {
        [TestClass]
        public class OrderedDictionaryTests {
            private OrderedDictionary<string, string> GetAlphabetDictionary(IEqualityComparer<string> comparer = null) {
                OrderedDictionary<string, string> alphabet = (comparer == null ? new OrderedDictionary<string, string>() : new OrderedDictionary<string, string>(comparer));
                for (var a = Convert.ToInt32('a'); a <= Convert.ToInt32('z'); a++) {
                    var c = Convert.ToChar(a);
                    alphabet.Add(c.ToString(), c.ToString().ToUpper());
                }
                Assert.AreEqual(26, alphabet.Count);
                return alphabet;
            }
            private List<KeyValuePair<string, string>> GetAlphabetList() {
                var alphabet = new List<KeyValuePair<string, string>>();
                for (var a = Convert.ToInt32('a'); a <= Convert.ToInt32('z'); a++) {
                    var c = Convert.ToChar(a);
                    alphabet.Add(new KeyValuePair<string, string>(c.ToString(), c.ToString().ToUpper()));
                }
                Assert.AreEqual(26, alphabet.Count);
                return alphabet;
            }
            [TestMethod]
            public void TestAdd() {
                var od = new OrderedDictionary<string, string>();
                Assert.AreEqual(0, od.Count);
                Assert.AreEqual(-1, od.IndexOf("foo"));
                od.Add("foo", "bar");
                Assert.AreEqual(1, od.Count);
                Assert.AreEqual(0, od.IndexOf("foo"));
                Assert.AreEqual(od[0], "bar");
                Assert.AreEqual(od["foo"], "bar");
                Assert.AreEqual(od.GetItem(0).Key, "foo");
                Assert.AreEqual(od.GetItem(0).Value, "bar");
            }
            [TestMethod]
            public void TestRemove() {
                var od = new OrderedDictionary<string, string>();
                od.Add("foo", "bar");
                Assert.AreEqual(1, od.Count);
                od.Remove("foo");
                Assert.AreEqual(0, od.Count);
            }
            [TestMethod]
            public void TestRemoveAt() {
                var od = new OrderedDictionary<string, string>();
                od.Add("foo", "bar");
                Assert.AreEqual(1, od.Count);
                od.RemoveAt(0);
                Assert.AreEqual(0, od.Count);
            }
            [TestMethod]
            public void TestClear() {
                var od = GetAlphabetDictionary();
                Assert.AreEqual(26, od.Count);
                od.Clear();
                Assert.AreEqual(0, od.Count);
            }
            [TestMethod]
            public void TestOrderIsPreserved() {
                var alphabetDict = GetAlphabetDictionary();
                var alphabetList = GetAlphabetList();
                Assert.AreEqual(26, alphabetDict.Count);
                Assert.AreEqual(26, alphabetList.Count);
                var keys = alphabetDict.Keys.ToList();
                var values = alphabetDict.Values.ToList();
                for (var i = 0; i < 26; i++) {
                    var dictItem = alphabetDict.GetItem(i);
                    var listItem = alphabetList[i];
                    var key = keys[i];
                    var value = values[i];
                    Assert.AreEqual(dictItem, listItem);
                    Assert.AreEqual(key, listItem.Key);
                    Assert.AreEqual(value, listItem.Value);
                }
            }
            [TestMethod]
            public void TestTryGetValue() {
                var alphabetDict = GetAlphabetDictionary();
                string result = null;
                Assert.IsFalse(alphabetDict.TryGetValue("abc", out result));
                Assert.IsNull(result);
                Assert.IsTrue(alphabetDict.TryGetValue("z", out result));
                Assert.AreEqual("Z", result);
            }
            [TestMethod]
            public void TestEnumerator() {
                var alphabetDict = GetAlphabetDictionary();
                var keys = alphabetDict.Keys.ToList();
                Assert.AreEqual(26, keys.Count);
                var i = 0;
                foreach (var kvp in alphabetDict) {
                    var value = alphabetDict[kvp.Key];
                    Assert.AreEqual(kvp.Value, value);
                    i++;
                }
            }
            [TestMethod]
            public void TestInvalidIndex() {
                var alphabetDict = GetAlphabetDictionary();
                try {
                    var notGonnaWork = alphabetDict[100];
                    Assert.IsTrue(false, "Exception should have thrown");
                }
                catch (Exception ex) {
                    Assert.IsTrue(ex.Message.Contains("index is outside the bounds"));
                }
            }
            [TestMethod]
            public void TestMissingKey() {
                var alphabetDict = GetAlphabetDictionary();
                try {
                    var notGonnaWork = alphabetDict["abc"];
                    Assert.IsTrue(false, "Exception should have thrown");
                }
                catch (Exception ex) {
                    Assert.IsTrue(ex.Message.Contains("key is not present"));
                }
            }
            [TestMethod]
            public void TestUpdateExistingValue() {
                var alphabetDict = GetAlphabetDictionary();
                Assert.IsTrue(alphabetDict.ContainsKey("c"));
                Assert.AreEqual(2, alphabetDict.IndexOf("c"));
                Assert.AreEqual(alphabetDict[2], "C");
                alphabetDict[2] = "CCC";
                Assert.IsTrue(alphabetDict.ContainsKey("c"));
                Assert.AreEqual(2, alphabetDict.IndexOf("c"));
                Assert.AreEqual(alphabetDict[2], "CCC");
            }
            [TestMethod]
            public void TestInsertValue() {
                var alphabetDict = GetAlphabetDictionary();
                Assert.IsTrue(alphabetDict.ContainsKey("c"));
                Assert.AreEqual(2, alphabetDict.IndexOf("c"));
                Assert.AreEqual(alphabetDict[2], "C");
                Assert.AreEqual(26, alphabetDict.Count);
                Assert.IsFalse(alphabetDict.ContainsValue("ABC"));
                alphabetDict.Insert(2, "abc", "ABC");
                Assert.IsTrue(alphabetDict.ContainsKey("c"));
                Assert.AreEqual(2, alphabetDict.IndexOf("abc"));
                Assert.AreEqual(alphabetDict[2], "ABC");
                Assert.AreEqual(27, alphabetDict.Count);
                Assert.IsTrue(alphabetDict.ContainsValue("ABC"));
            }
            [TestMethod]
            public void TestValueComparer() {
                var alphabetDict = GetAlphabetDictionary();
                Assert.IsFalse(alphabetDict.ContainsValue("a"));
                Assert.IsTrue(alphabetDict.ContainsValue("a", StringComparer.OrdinalIgnoreCase));
            }
            [TestMethod]
            public void TestSortByKeys() {
                var alphabetDict = GetAlphabetDictionary();
                var reverseAlphabetDict = GetAlphabetDictionary();
                Comparison<string> stringReverse = ((x, y) => (String.Equals(x, y) ? 0 : String.Compare(x, y) >= 1 ? -1 : 1));
                reverseAlphabetDict.SortKeys(stringReverse);
                for (int j = 0, k = 25; j < alphabetDict.Count; j++, k--) {
                    var ascValue = alphabetDict.GetItem(j);
                    var dscValue = reverseAlphabetDict.GetItem(k);
                    Assert.AreEqual(ascValue.Key, dscValue.Key);
                    Assert.AreEqual(ascValue.Value, dscValue.Value);
                }
            }
