     private IUploadRepository _uploadRepository;
     private ISalesRepository _salesRepository; 
     private ITRSalesRepository _trsalesRepository;
     private ILocalPurchaseRepository _localRepository;
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
