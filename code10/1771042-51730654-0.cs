    public class TimeOffManager : Controller
    {
       private readonly IUnitOfWork _uow;
       private readonly IRequestBuilder ptoBuilder;
       private readonly IRequestBuilder utoBuilder;
    
       public TimeOffManager(IUnitOfWork uow, IRequestBuilder ptoBuilder, IRequestBuilder utoBuilder)
       {
           _uow = uow;
           this.ptoBuilder = ptoBuilder;
           this.utoBuilder = utoBuilder;
       }
    
       [HttpPost]
       public ActionResult RequestPto(PtoFormVm vm)
       {
           //validate view model...
    
           ITimeOffRequest pto = ptoBuilder
                                   .Id(vm.Id)
                                   .InRange(vm.StartDate, vm.EndDate)
                                   .State((RequestState)vm.State)
                                   .Note(vm.Comment)
                                   .Build();
           // Etc...
       }
    
       [HttpPost]
       public ActionResult RequestUto(UtoFormVm vm)
       {
           //validate view model...
    
           ITimeOffRequest uto = utoBuilder()
                                   .Id(vm.Id)
                                   .IsFullDay(vm.FullDay)
                                   .InRange(vm.StartDate, vm.EndDate)
                                   .State((RequestState)vm.State)
                                   .Note(vm.Comment)
                                   .Build();
           // Etc...
       }
    }
