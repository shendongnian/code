    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost sh=new ServiceHost(typeof(MyService)))
            {
                sh.Open();
                Console.WriteLine("Service is ready....");
                Console.ReadLine();
                sh.Close();
            }
        }
    }
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        int Mult(int x, int y);
    }
    public class MyService : IService
    {
        public int Mult(int x, int y)
        {
            OperationContext oc = OperationContext.Current;
            Console.WriteLine(oc.Channel.LocalAddress.Uri);
            return x * y;
        }       
     }
