    [TestFixture]
    class SomeTests
    {
        [Test]
        public void AsyncTest()
        {
            var result = false;
            var Some = new Some();
            Some.AsyncFunction(e =>
            {
                result = e.Result;
            });
                        
            Assert.That(() => result, Is.True.After(1).Minutes.PollEvery(500).MilliSeconds);
        }
    
    }
