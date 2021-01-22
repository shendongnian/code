    [TestClass]
    public class WhenMethodToTestIsCalled()
    {
        [TestMethod]
        public void ThenEverythingIsExecutedInAnTransaction()
        {
            var transactionCommitted = false;
            var fooTransaction = (Transaction)null;
            var barTransaction = (Transaction)null;
            var dataLayerMock = new Mock<IDataLayer>();
            dataLayerMock.Setup(dataLayer => dataLayer.Foo())
                         .Callback(() =>
                                   {
                                       fooTransaction = Transaction.Current;
                                       fooTransaction.TransactionCompleted +=
                                           (sender, args) =>
                                           transactionCommitted = args.Transaction.TransactionInformation.Status == TransactionStatus.Committed;
                                   });
            dataLayerMock.Setup(dataLayer => dataLayer.Bar())
                         .Callback(() => barTransaction = Transaction.Current);
            var unitUnderTest = new Foo(dataLayerMock.Object);
            unitUnderTest.MethodToTest();
            // A transaction was used for Foo()
            fooTransaction.Should().NotBeNull();
            // The same transaction was used for Bar()
            barTransaction.Should().BeSameAs(fooTransaction);
            // The transaction was committed
            transactionCommitted.Should().BeTrue();
        }
    }
