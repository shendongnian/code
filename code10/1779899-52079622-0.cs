    services.MockLogProvider.Verify(x => x.LogExceptionAsync(
       It.Is<Exception>(e => e.Message == "Order doesn't exist on ERP"), 
       It.IsAny<string>(), 
       It.IsAny<string>(), 
       It.IsAny<Dictionary<string, string>>(), 
       It.IsAny<string>(), 
       It.IsAny<string>(), 
       It.IsAny<int>()));
