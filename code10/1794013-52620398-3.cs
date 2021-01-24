    string json = Newtonsoft.Json.JsonConvert.SerializeObject(your_object);
    System.IO.Ports.SerialPort Port = new System.IO.Ports.SerialPort("COM1");
    Port.BaudRate = 9600;
    Port.Open();
    Port.WriteTimeout = 4000;
    Port.Write(json);
