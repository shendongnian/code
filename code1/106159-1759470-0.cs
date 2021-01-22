    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.Runtime.Serialization;
    using System;
    
    [ServiceContract]
    public interface  AddStuff
    {
        [OperationContract]
        int Add(int X,int Y);
    }
    
    public class opAddStuff : AddStuff
    {
        public int Add(int X, int Y)
        {
            return X + Y;
        }
    }
    
    public class Pgm
    {
        static void Main(string[] args)
        {
            string httpAddr = "http://127.0.0.1:6001/AddStuff";
            string netAddr= "net.tcp://127.0.0.1:5001/AddStuff";
    
            System.ServiceModel.ServiceHost SH = new ServiceHost(typeof(opAddStuff),new Uri(httpAddr));
    
            BasicHttpBinding B = new BasicHttpBinding();
            NetTcpBinding NB = new NetTcpBinding();
            
            SH.AddServiceEndpoint(typeof(AddStuff), B, httpAddr);
            SH.AddServiceEndpoint(typeof(AddStuff), NB, netAddr);
    
    
    
            System.ServiceModel.Description.ServiceMetadataBehavior smb = SH.Description.Behaviors.Find<ServiceMetadataBehavior>();
            // If not, add one
            if (smb == null)
                smb = new ServiceMetadataBehavior();
    
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            
            SH.Description.Behaviors.Add(smb);
            SH.AddServiceEndpoint(  ServiceMetadataBehavior.MexContractName,  MetadataExchangeBindings.CreateMexHttpBinding(),  "mex");
    
            SH.Open();
    
            Console.WriteLine("Service at your service");
            string crap = Console.ReadLine();
    
    
    
        }
    }
