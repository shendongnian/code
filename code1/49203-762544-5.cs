      class Foo : MarshalByRefObject, IInterceptorNotifiable {
            public int PublicProp { get; set; }
            public string lastPropertyChanged;
            public void OnPropertyChanged(string propertyName) {
                lastPropertyChanged = propertyName;
            }
        }
        [Test]
        public void TestPropertyInterception() {
            var foo = Interceptor<Foo>.Create();
            foo.PublicProp = 100;
            
            Assert.AreEqual("PublicProp", foo.lastPropertyChanged);
        }
    }
