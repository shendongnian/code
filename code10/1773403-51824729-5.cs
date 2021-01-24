    public ICollection<ViewModelInvoiceProduct> AddedInvoiceProductsViewModel {get;set;}
    public ICollection<InvoiceProducts> AddedInvoiceProducts
        {
            get
            {
                return invoiceProducts;
            }
            set
            {
                invoiceProducts = value;
                //the idea to populate AddedInvoiceProductsViewModel
                foreach(var invoice in invoiceProducts)
                {
                    var temp = new ViewModelInvoiceProduct();
                    temp.XXX = invoice.XXX;
                    temp.CGST = 1 + 2;
                    AddedInvoiceProductsViewModel.Add(temp);
                }
            }
        }
