    public class BaseClass
    {
        public int DataТype { get; set; }
        
        public object Data { get; set; }
    }
    public class DataClass<T>
    {
        public DataClass(T initialValue)
        {
            Property = initialValue;
        }
        public T Property { get; set; }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            List<BaseClass> listBaseClass = new List<BaseClass>();
            BaseClass dummy = new BaseClass();
            dummy.DataТype = 1;
            dummy.Data = new DataClass<int>(50);
            listBaseClass.Add(dummy);
            if (listBaseClass[0].DataТype == 1)
            {
                DataClass<int> casted = (DataClass<int>)listBaseClass[0].Data;     
                Console.WriteLine(casted.Property);
            }      
        }
    }
