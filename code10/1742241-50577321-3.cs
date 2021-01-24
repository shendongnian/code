    namespace ViewModel;
    interface IDatabaseRepository {
       DataObject LoadData()
    }
    
    namespace DataLayer;
    class DataRepository {
       public DataRepository(DbContext context) {
          this.context = context;
       }
    
       public DataObject LoadData() {
          //load data from DB using dbContext
       }
    }
    
    namespace ViewModel;
    class ViewModel {
       public ViewModel(IDataRepository repository) {
          this.repository = repository;
       }
       
       // use the repository inside this class to acces data
    }
