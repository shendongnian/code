         //Db context 
         Infomaster _dbContext;
         
         //User is a model from my EF
         public IRepository<User> UserRepository { get; private set; }
         public UnitOfWork()
         {
             _dbContext = new Infomaster();
      
              UserRepository = new Repository<User>(_dbContext);
         }
         public int Commit()
         {
              return _dbContext.Save(); 
         }
    }
