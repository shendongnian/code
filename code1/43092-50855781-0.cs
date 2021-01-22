    class InventoryAndSales
    {
        public int InvoiceNumber { get; set; }
    }
    //if someone calls for this class then the InvoiceNumber type is now object 
    class NewInventoryAndSales : InventoryAndSales
    {
        public new object InvoiceNumber { get; set; }
    }
