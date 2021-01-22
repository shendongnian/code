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
            //Use MySQL connector to get data.
            return data;
        }
        public void SaveData(Data dataToSave)
        {
            //Use MySQL connector to save to data.
        }
        public void DeleteData(Data dataToDelete)
        {
            //Use MySQL connector to delete passed in data.
        }
    }
