    System.Type getTypeOfForm(string docType) {
        switch (docType) {
            case "Customer":
                return typeof(MyNameSpace.CustomerMDIForm);
            case "Invoice":
                return typeof(MyNameSpace.InvoiceMDIForm);
            case "Order":
                return typeof(MyNameSpace.OrderMDIForm);
                
                ...
            
            default:
                throw new Exception("Unknown Form Type");
        }
    }
