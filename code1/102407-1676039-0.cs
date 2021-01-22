    public interface IDataLayer
        {
            IList<Data> GetData();
            void SaveData(Data dataToSave);
            void DeleteData (Data dataToDelete);
        }
    
    public class MySqlDataLayer : IDataLayer
    {
      public IList<Data> GetData()
      {
         //use MySql connector to get data
         return data;
      }
    
      public void SaveData(Data dataToSave)
      {
          //use MySql connector to save to data
      }
    
      public void DeleteData(Data dataToDelete)
      {
        //use MySql connector to delete passed in data
      }
    }
