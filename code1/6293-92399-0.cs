    using(Socket socket = ...){
      NetworkStream ns = new NetworkStream(socket);      
      ns.WriteByte((size>>24) & 0xFF);
      ns.WriteByte((size>>16) & 0xFF);
      ns.WriteByte((size>>8)  & 0xFF);
      ns.WriteByte( size      & 0xFF);
      // write the actual message
    }
