    public Class When_an_order_is_placed
    {
        [Setup]
        public void TestSetup() {
            Order o = CreateTestOrder();
            mockedEmailService = CreateTestEmailService(); // this is what you want to mock
            IOrderService orderService = CreateTestOrderService(mockedEmailService);
            orderService.SubmitOrder(o);
        } 
    
        [Test]
        public void A_confirmation_email_should_be_sent() {
            Assert.IsTrue(mockedEmailService.SentMailMessage != null);
        }
    
    
        [Test]
        public void The_email_should_go_to_the_customer() {
            Assert.IsTrue(mockedEmailService.SentMailMessage.To.Contains("test@hotmail.com"));
        }
    
    }
