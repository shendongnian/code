        [Test]
        [ExpectedException(typeof(ArgumentException), Message = "test string")]
        public void BarFoo_Exception()
        {
            IXyz xyzStub = MockRepository.GenerateStub<IXyz>();
            xyzStub.Stub(x => x.Foo()).Throw(new ArgumentException("test string"));
            new Sut().Bar(xyzStub);
        }
