        public ActionResult Index(int? page, string searchInvoiceNumber)
        {
            private DataViewModel dataViewModel = new DataViewModel();
            var model = new TransaksiSelectionViewModel();
            IPagedList<Payment> Payments = null;
            Payments = paymentRepo.GetList_Payments_InTableManualPayment(pageSize, pageNumber);
    
           var editorViewModelList = new List<SelectTransaksiEditorViewModel>();
           foreach (var item in Payments )
           {
                var editorViewModel = new SelectTransaksiEditorViewModel()
                {
                    Id = item.ID,
                    InvoiceNumber = item.InvoiceNumber,
                    ContractNumber = item.ContractNumber,
                    ConsumerName = item.ConsumerName,
                };
    
                if (!String.IsNullOrEmpty(searchInvoiceNumber))
                {
                  if (editorViewModel.InvoiceNumber.Contains(searchInvoiceNumber))
    	          {
                       editorViewModelList.Add(editorViewModel);
                  }
                }
             }
          model.Transactions.Add(editorViewModelList);
          dataViewModel.transaksiSelectionViewModel = model;
          return View(dataViewModel);
       }
