    [TextFixture]
    public void TestClass {
    
        private class TestFoo : AbstractFoo {
            boolean hasCalledSpecificCode = false;
            public void SpecificCode() {
                hasCalledSpecificCode = true;
            }
        }
        [Test]
        public void testCommonCallsSpecificCode() {
            TestFoo fooFighter = new TestFoo();
            fooFighter.CommonCode();
            Assert.That(fooFighter.hasCalledSpecificCode, Is.True());
        }
    }
