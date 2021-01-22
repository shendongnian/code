     [Test]
        public void You_can_check_to_see_if_a_method_was_called()
        {
            var stub = MockRepository.GenerateStub<ISampleClass>();
            stub.MethodThatReturnsInteger("foo");
            stub.AssertWasCalled(s => s.MethodThatReturnsInteger("foo"));
            stub.AssertWasCalled(s => s.MethodThatReturnsInteger(Arg<string>.Is.Anything));
        }
