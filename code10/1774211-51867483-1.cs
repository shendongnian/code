    public async Task GetPaymentDetailSummaryTestAsync(){                        
        //Arrange
        List<PaymentSummary> expected = new List<PaymentSummary> {
            new PaymentSummary {
                PaymentNumber = 1,
                Payment = 1200.00
            }
        };
        var json = JsonConvert.SerializeObject(expected);
    
        var mock = new Mock<ICallProcedure>();
        mock.Setup(_ => _.GetResults(It.IsAny<string>(), It.IsAny<object>())) 
            .ReturnsAsync(json);            
    
        var payments = new Payments(mock.Object);
        //Act
        var actual = await payments.GetPaymentDetailSummaryAsync(2018, 600002);
        //Assert
        Assert.IsNotNull(actual);
        Assert.IsInstanceOfType(actual, typeof(List<PaymentSummary>));
        Assert.AreEqual(1, actual.Count);
        CollectionAssert.AreEquivalent(expected, actual);
    }
