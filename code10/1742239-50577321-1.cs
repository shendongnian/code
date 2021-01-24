    namespace ViewModel;
    interface IDatabaseRepository {
       DataObject LoadData()
    }
    
    namespace DataLayer;
    class DataRepository {
       public DataRepository(DbConnectionProvider provider) {
          this.provider = provider;
       }
    
       public DataObject() {
          //load data from DB using provider
       }
    }
    
    namespace ViewModel;
    class ViewModel {
       public ViewModel(IDataRepository repository) {
          this.repository = repository;
       }
       
       // use the repository inside this class to acces data
    }
