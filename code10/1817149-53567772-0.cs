    public void Comenzar(IPAdress ipAddress, int puerto) {
        this.puerto = puerto;
        Console.WriteLine("\n\nCliente esperando por una conexion...");
        todoListo.Reset();
        Socket emisor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        emisor.BeginConnect(new IPEndPoint(ipAddress, puerto), Conectar, emisor);
        todoListo.WaitOne();
      }
