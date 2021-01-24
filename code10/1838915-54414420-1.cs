    public class MyController: Controller
    {
      private IBookRepository _bookRepository;
      private IStatusRepository _statusRepository;
      public MyController(IBookRepository bookRepository, IStatusRepository statusRepository)
      {
        _bookRepository = bookRepository; 
        _statusRepository = statusRepository
      }
    }
