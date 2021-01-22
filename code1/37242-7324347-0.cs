     public interface IEntity
        {
            int ID
            {
                get;
                set;
            }
        }
    public class Entity2:IEntity
        {
            public string Property2;
    
            public int ID
            {
                get
                {
                    throw new NotImplementedException();
                }
                set
                {
                    throw new NotImplementedException();
                }
            }
        }
