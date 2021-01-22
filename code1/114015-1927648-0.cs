    var re = new System.Text.RegularExpressions.Regex("(?<=^PurchaseOrder)PO\\d{10}(?=\\.pdf$)");
    Assert.IsTrue(re.IsMatch("PurchaseOrderPO1234567890.pdf"));
    Assert.IsFalse(re.IsMatch("some PurchaseOrderPO1234567890.pdf"));
    Assert.IsFalse(re.IsMatch("OrderPO1234567890.pdf"));
    Assert.IsFalse(re.IsMatch("PurchaseOrderPO1234567890.pdf2"));
