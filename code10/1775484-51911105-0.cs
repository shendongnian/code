       public class TernaryChallenge
        {
            public string playerName;
            public string OnDisable1()
            {
                string name = (playerName != "" && playerName != null) ? "Hello " + 
                playerName : "Hello Player 1!";
                return name;
            }
    
            public string OnDisable2()
            {
                string name = (playerName != null && playerName != "") ? "Hello " + 
                playerName : "Hello Player 1!";
                return name;
            }
    
            public string OnDisable3()
            {
                string name = !string.IsNullOrEmpty(playerName) ? "Hello " + playerName : 
                "Hello Player 1!";
                return name;
            }
    
    [TestMethod]
            public void TestMethod1()
            {
                var ternaryChallenge = new TernaryChallenge();
    
                string actual = ternaryChallenge.OnDisable1();
                string expected = "Hello Player 1!";
                Assert.AreEqual(expected, actual, ignoreCase: false);
    
                actual = ternaryChallenge.OnDisable2();
                expected = "Hello Player 1!";
                Assert.AreEqual(expected, actual, ignoreCase: false);
    
                actual = ternaryChallenge.OnDisable3();
                expected = "Hello Player 1!";
                Assert.AreEqual(expected, actual, ignoreCase: false);
            }
    
            [TestMethod]
            public void TestMethod2()
            {
                var ternaryChallenge = new TernaryChallenge
                {
                    playerName = null
                };
    
                string actual = ternaryChallenge.OnDisable1();
                string expected = "Hello Player 1!";
                Assert.AreEqual(expected, actual, ignoreCase: false);
    
                actual = ternaryChallenge.OnDisable2();
                expected = "Hello Player 1!";
                Assert.AreEqual(expected, actual, ignoreCase: false);
    
                actual = ternaryChallenge.OnDisable3();
                expected = "Hello Player 1!";
                Assert.AreEqual(expected, actual, ignoreCase: false);
            }
