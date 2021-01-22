    public interface ICrud
    {
        void Add();
        void Update();
        void Delete();
        void Select();
    }
    public abstract class CrudBase
    {
        public void Add()
        {
            Console.WriteLine("Performing add operation...");
            Console.ReadLine();
        }
        
       public void Update()
        {
            Console.WriteLine("Performing update operation...");
            Console.ReadLine();
        }
        public void Delete()
        {
            Console.WriteLine("Performing delete operation...");
            Console.ReadLine();
        }
        public void Select()
        {
            Console.WriteLine("Performing select operation...");
            Console.ReadLine();
        }
    }
    public class ProcessData : CrudBase, ICrud
    {
    }
    var process = new ProcessData();
    process.Add();
