          delegate void MockOutDelegate(string s, out int value);
        public void SomeMethod()
        {
            ....
             int value;
             myMock.Setup(x => x.TryDoSomething(It.IsAny<string>(), out value))
                .Callback(new MockOutDelegate((string s, out int output) => output = userId))
                .Returns(true);
        }
