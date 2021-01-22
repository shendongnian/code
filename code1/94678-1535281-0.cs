    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Should_throw_ArgumentNullException_when_the_Order_is_null()
    {
        OrderProcessor processor = new OrderProcessor();
        processor.ProcessOrder(null);
    }
