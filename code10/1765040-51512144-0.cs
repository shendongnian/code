    public class PlcChecker
    {
       TcpClient client {get;set;}
       ModbusIpMaster master{get;set;}
       
       public PlcChecker()
       {
    	  client= new TcpClient();
        }
      
        public async Task Connect(string ip,int port)
        {
          ModbusIpMaster master = ModbusIpMaster.CreateIp(client);
          client.Connect(ip,port);
        }
      
         public async Task<bool> Check()
         {
           //your code to call master and while(true)
         }
      
    }
     public class YourWinForm
    {
        public PlcChecker plcChekcer { get; private set; }
  
        private async void toolStripButton2_Click(object sender, EventArgs e)
        {
            plcChekcer = new PlcChecker();
            await plcChekcer.Connect("192.168.0.1", 502);
            bool result = await plcChekcer.Check();
            if(result)
            {
                 //do something   
            }
            
        }
    }
