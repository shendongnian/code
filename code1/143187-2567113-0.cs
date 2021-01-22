    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestEventRaised()
        {
            // arrange
            var called = false;
    
            var test = new ObjectUnderTest();
            test.WidthChanged += (sender, args) => called = true;
            
            // act
            test.Width = 42;
    
            // assert
            Assert.IsTrue(called);
        }
    
        private class ObjectUnderTest
        {
            private int _width;
            public event EventHandler WidthChanged;
    
            public int Width
            {
                get { return _width; }
                set
                {
                    _width = value; OnWidthChanged();
                }
            }
    
            private void OnWidthChanged()
            {
                var handler = WidthChanged;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
        }
    }
