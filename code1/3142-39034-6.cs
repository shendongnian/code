    [TestFixture]
    public void TestClass extends AbstractFoo {
        
        boolean hasCalledSpecificCode;
        public void specificCode() {
            hasCalledSpecificCode = true;
        }
        
        [Test]
        public void testCommonCallsSpecificCode() {
            AbstractFoo fooFighter = this;
            hasCalledSpecificCode = false;
            fooFighter.CommonCode();
            Assert.That(fooFighter.hasCalledSpecificCode, Is.True());
        }        
    }
