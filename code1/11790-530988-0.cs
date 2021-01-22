        [Test]
        public void Test()
        {
            var myClass = new MyClass
                              {
                                  TheValue = 500
                              };
            myClass.TheValue += 500;
            Assert.That(myClass.TheValue.Value.Amount, Is.EqualTo(1000));
        }
        private class MyClass
        {
            public MyStruct? TheValue { get; set; }
        }
        private struct MyStruct
        {
            public decimal Amount { get; private set; }
            public MyStruct(decimal amount) : this()
            {
                Amount = amount;
            }
            public static MyStruct operator +(MyStruct x, MyStruct y)
            {
                return new MyStruct(x.Amount + y.Amount);
            }
            public static MyStruct operator +(MyStruct x, decimal y)
            {
                return new MyStruct(x.Amount + y);
            }
            public static implicit operator MyStruct(int value)
            {
                return new MyStruct(value);
            }
            public static implicit operator MyStruct(decimal value)
            {
                return new MyStruct(value);
            }
        }
