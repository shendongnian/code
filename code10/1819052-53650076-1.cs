    class A
    { 
        public UdpClient UdpClient { get; set; } = new UdpClient();
    }
            
    var a = new A();
    var ml = a.UdpClient.Client.MulticastLoopback; // ok here
    
    JsonConvert.SerializeObject(a); // Exception here
