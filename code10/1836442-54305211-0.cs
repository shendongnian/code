    [Fact]
        public void GivenAnOrderConfirmedEventWithForcedAccountId_WhenHandle_ThenCallSenderWithTheForcedAccountId()
        {
            NServiceBus.Testing.Test.Initialize();
            mockSender.Expect(x => x.Create(Arg<ShipmentConfirmedDto>.Matches(dto => dto.AccountId == 2222), Arg<string>.Is.Equal("ANDROID"))).Return(string.Empty);
            mockSender.Expect(x => x.Create(Arg<ShipmentConfirmedDto>.Matches(dto => dto.AccountId == 1111), Arg<string>.Is.Equal("IOS"))).Return(string.Empty);
            var service = new ShipmentConfirmedRequestEventConsumer(mockSender, "1111", "2222");
            NServiceBus.Testing.Test.Handler(svc => service)
                .OnMessage<ShipmentConfirmedEvent>(
                    m =>
                    {
                        m.AccountId = 407716;
                        m.CustomerFirstName = "Marco";
                        m.TransactionId = "T123456";
                        m.LanguageCode = "IT";
                        m.TrackingNumber = "642167921";
                    }
                );
            mockSender.VerifyAllExpectations();
        }
