     IUploadRepository _uploadRepository;
     ISalesRepository _salesRepository; 
     ITRSalesRepository _trsalesRepository;
     ILocalPurchaseRepository _localRepository;
     public HomeController(
          IUploadRepository uploadRepository,
          ISalesRepository salesRepository,
          ITRSalesRepository trsalesRepository,
          ILocalPurchaseRepository localRepository
     )
     {
         this._uploadRepository = uploadRepository;
         this._salesRepository= salesRepository;
         this._trsalesRepository= trsalesRepository;
         this._localRepository= localRepository;
     }
