    using System; 
    using System.Text; 
    using System.IO; 
    using System.IO.Pipes; 
     
    namespace CSPipe 
    { 
      class Program 
      { 
        static void Main(string[] args) 
        { 
          NamedPipeClientStream pipe = new NamedPipeClientStream(".", "HyperPipe", PipeDirection.InOut); 
          pipe.Connect(); 
          using (StreamReader rdr = new StreamReader(pipe, Encoding.Unicode)) 
          { 
            System.Console.WriteLine(rdr.ReadToEnd()); 
          } 
     
          Console.ReadKey(); 
        } 
      } 
    }
