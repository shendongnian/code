    public interface IRepository
    {
    	void Init();
    	IList<int> Get();
    }
    public Class A 
    {    
      IRepository _aRepository;
      IRepository _bRepository;
      IRepository _cRepository;
        
      public A(IRepository aRepository, IRepository bRepository, IRepository bRepository)
      {
    	_aRepository = aRepository;
    	_bRepository = bRepository;
    	_cRepository = cRepository;
      
         MethodB();
      }
    
      public IList<int> GetA()
      {
          return _aRepository.Get();
      } 
    
      public IList<int> GetB()
      {
          return _bRepository.Get();
      } 
      public IList<int> GetC()
      {
          return _cRepository.Get();
      } 
    
      private void MethodB()
      {
          _aRepository.Init();
    	  _bRepository.Init();
    	  _cRepository.Init();
      }
     
      public bool MethodA(customerCollection foo){...whatever...}
    }
