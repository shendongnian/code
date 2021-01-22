    public interface IYourName
    {
        int AddEdit(int? id, string name);
        DataTable Get(int? id);
    }
    public class DALF
    {
       public class Car : IYourName
        {
            public int AddEdit(int? CarId, string Name)
            {
                //....
            }
            public DataTable Get(int? CarId)
            {
                //.....
                return CarD.Get(obj);
            }
        }
        public class Worker : IYourName
        {
            public int AddEdit(int? WorkerId, string Name)
            {
                //....
            }
            public DataTable Get(int? WorkerId)
            {
                //.....
                return carD.Get(obj);
            }
        }
    }
