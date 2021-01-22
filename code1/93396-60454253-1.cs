    [TestFixture]
        class PrimeNumbersKataTest
        {
            private PrimeNumbersKata primeNumbersKata;
            [SetUp]
            public void Init()
            {
                primeNumbersKata = new PrimeNumbersKata();
            }
            [TestCase(1,0)]
            [TestCase(0,0)]
            [TestCase(2,1)]
            [TestCase(3,2)]
            [TestCase(5,3)]
            [TestCase(7,4)]
            [TestCase(9,4)]
            [TestCase(11,5)]
            [TestCase(13,6)]
            public void CountPrimeNumbers_N_AsArgument_returnCountPrimes(int n, int expected)
            {
                //arrange
                //act
                var actual = primeNumbersKata.CountPrimeNumbers(n);
                //assert
                Assert.AreEqual(expected,actual);
            }
            
            [Test]
            public void CountPrimairs_N_IsNegative_RaiseAnException()
            {
                var ex = Assert.Throws<ArgumentException>(()=> { primeNumbersKata.CountPrimeNumbers(-1); });
                //Assert.That(ex.Message == "Not valide numbre");
                 Assert.That(ex.Message, Is.EqualTo("Not valide numbre"));
    
            }
        }
