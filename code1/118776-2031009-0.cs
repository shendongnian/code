    public interface IDBProvider {
       // ... list of DB operations you care about
       List<Products> GetProducts(string vendor)
    }
    
    public class SomeWorkerClass {
       private IDBProvider dbConnection;
    
       public SomeWorkerClass(IDBProvider dbProvider) {
          dbConnection = dbProvider;
       }
    
       public void SomeFunction() {
          List<Products> = dbConnection.GetProducts("test");
       } 
    }
