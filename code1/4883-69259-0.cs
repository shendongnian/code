    public class TestPayments
    {
        InvoiceDiaryHeader invoiceHeader = null;
        InvoiceDiaryDetail invoiceDetail = null;
        BankCashDiaryHeader bankHeader = null;
        BankCashDiaryDetail bankDetail = null;
        public InvoiceDiaryHeader CreateSales(string amountIncVat, bool sales, int invoiceNumber, string date)
        {
            ......
            ......
        }
        public BankCashDiaryHeader CreateMultiplePayments(IList<InvoiceDiaryHeader> invoices, int headerNumber, decimal amount, decimal discount)
        {
           ......
           ......
        }
        [TestMethod]
        public void TestSingleSalesPaymentNoDiscount()
        {
            IList<InvoiceDiaryHeader> list = new List<InvoiceDiaryHeader>();
            list.Add(CreateSales("119", true, 1, "01-09-2008"));
            bankHeader = CreateMultiplePayments(list, 1, 119.00M, 0);
            bankHeader.Save();
            
            Assert.AreEqual(1, bankHeader.BankCashDetails.Count);
            Assert.AreEqual(1, bankHeader.BankCashDetails[0].Payments.Count);
            Assert.AreEqual(119M, bankHeader.BankCashDetails[0].Payments[0].PaymentAmount);
            Assert.AreEqual(0M, bankHeader.BankCashDetails[0].Payments[0].PaymentDiscount);
            Assert.AreEqual(0, bankHeader.BankCashDetails[0].Payments[0].InvoiceHeader.Balance);
        }
        [TestMethod]
        public void TestSingleSalesPaymentDiscount()
        {
            IList<InvoiceDiaryHeader> list = new List<InvoiceDiaryHeader>();
            list.Add(CreateSales("119", true, 2, "01-09-2008"));
            bankHeader = CreateMultiplePayments(list, 2, 118.00M, 1M);
            bankHeader.Save();
            Assert.AreEqual(1, bankHeader.BankCashDetails.Count);
            Assert.AreEqual(1, bankHeader.BankCashDetails[0].Payments.Count);
            Assert.AreEqual(118M, bankHeader.BankCashDetails[0].Payments[0].PaymentAmount);
            Assert.AreEqual(1M, bankHeader.BankCashDetails[0].Payments[0].PaymentDiscount);
            Assert.AreEqual(0, bankHeader.BankCashDetails[0].Payments[0].InvoiceHeader.Balance);
        }
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDuplicateInvoiceNumber()
        {
            IList<InvoiceDiaryHeader> list = new List<InvoiceDiaryHeader>();
            list.Add(CreateSales("100", true, 2, "01-09-2008"));
            list.Add(CreateSales("200", true, 2, "01-09-2008"));
            bankHeader = CreateMultiplePayments(list, 3, 300, 0);
            bankHeader.Save();
            Assert.Fail("expected an ApplicationException");
        }
        [TestMethod]
        public void TestMultipleSalesPaymentWithPaymentDiscount()
        {
            IList<InvoiceDiaryHeader> list = new List<InvoiceDiaryHeader>();
            list.Add(CreateSales("119", true, 11, "01-09-2008"));
            list.Add(CreateSales("400", true, 12, "02-09-2008"));
            list.Add(CreateSales("600", true, 13, "03-09-2008"));
            list.Add(CreateSales("25,40", true, 14, "04-09-2008"));
            bankHeader = CreateMultiplePayments(list, 5, 1144.00M, 0.40M);
            bankHeader.Save();
            Assert.AreEqual(1, bankHeader.BankCashDetails.Count);
            Assert.AreEqual(4, bankHeader.BankCashDetails[0].Payments.Count);
            Assert.AreEqual(118.60M, bankHeader.BankCashDetails[0].Payments[0].PaymentAmount);
            Assert.AreEqual(400, bankHeader.BankCashDetails[0].Payments[1].PaymentAmount);
            Assert.AreEqual(600, bankHeader.BankCashDetails[0].Payments[2].PaymentAmount);
            Assert.AreEqual(25.40M, bankHeader.BankCashDetails[0].Payments[3].PaymentAmount);
            Assert.AreEqual(0.40M, bankHeader.BankCashDetails[0].Payments[0].PaymentDiscount);
            Assert.AreEqual(0, bankHeader.BankCashDetails[0].Payments[1].PaymentDiscount);
            Assert.AreEqual(0, bankHeader.BankCashDetails[0].Payments[2].PaymentDiscount);
            Assert.AreEqual(0, bankHeader.BankCashDetails[0].Payments[3].PaymentDiscount);
            Assert.AreEqual(0, bankHeader.BankCashDetails[0].Payments[0].InvoiceHeader.Balance);
            Assert.AreEqual(0, bankHeader.BankCashDetails[0].Payments[1].InvoiceHeader.Balance);
            Assert.AreEqual(0, bankHeader.BankCashDetails[0].Payments[3].InvoiceHeader.Balance);
            Assert.AreEqual(0, bankHeader.BankCashDetails[0].Payments[3].InvoiceHeader.Balance);
        }
        [TestMethod]
        public void TestSettlement()
        {
            IList<InvoiceDiaryHeader> list = new List<InvoiceDiaryHeader>();
            list.Add(CreateSales("300", true, 43, "01-09-2008")); //Sales
            list.Add(CreateSales("100", false, 6453, "02-09-2008")); //Purchase
            bankHeader = CreateMultiplePayments(list, 22, 200, 0);
            bankHeader.Save();
            Assert.AreEqual(1, bankHeader.BankCashDetails.Count);
            Assert.AreEqual(2, bankHeader.BankCashDetails[0].Payments.Count);
            Assert.AreEqual(300, bankHeader.BankCashDetails[0].Payments[0].PaymentAmount);
            Assert.AreEqual(-100, bankHeader.BankCashDetails[0].Payments[1].PaymentAmount);
            Assert.AreEqual(0, bankHeader.BankCashDetails[0].Payments[0].InvoiceHeader.Balance);
            Assert.AreEqual(0, bankHeader.BankCashDetails[0].Payments[1].InvoiceHeader.Balance);
        }
