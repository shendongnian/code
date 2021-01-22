     public interface IUser
    {
         int ID { get; set; }
         string Name { get; set; }
    }
    public class NetworkUser : IUser
    {
        public int ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
    }
    public class Associate : NetworkUser,IUser
    {
        #region IUser Members
        public int ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        #endregion
    }
    public class Manager : NetworkUser,IUser
    {
        #region IUser Members
        public int ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        #endregion
    }
       
    public class Program
    {
        public static bool AreSame(Type sourceType, Type destinationType)
        {
            if (sourceType == null || destinationType == null)
            {
                return false;
            }
            if (sourceType == destinationType)
            {
                return true;
            }
            //walk up the inheritance chain till we reach 'object' at which point check if 
	    //the current destination type is assignable from the source type	   
	    Type tempDestinationType = destinationType;
            while (tempDestinationType.BaseType != typeof(object))
            {
                tempDestinationType = tempDestinationType.BaseType;
            }
            if( tempDestinationType.IsAssignableFrom(sourceType))
            {
                return true;
            }
            var query = from d in destinationType.GetInterfaces() join s in sourceType.GetInterfaces()
                        on d.Name equals s.Name
                        select s;
            //if the results of the query are not empty then we have a common interface , so return true 
	    if (query != Enumerable.Empty<Type>())
            {
                return true;
            }
            return false;            
        }
        public static void Main(string[] args)
        {
            AreSame(new Manager().GetType(), new Associate().GetType());
        }
    }
