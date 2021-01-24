        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.1", 6666);
            NetworkStream clientNetworkStream = client.GetStream();
            string fileContent = FileBase64Encoding(@"D:\Download\AtomSetup-x64.exe");
            byte[] fileBytes = Encoding.ASCII.GetBytes(fileContent);
            // byte[] fileLength = Encoding.ASCII.GetBytes(fileBytes.Length.ToString());
            Console.WriteLine(fileBytes.Length);
            // Write the length of a message
            var integerBytes = BitConverter.GetBytes(fileBytes.Length); // integer has 4 bytes
            clientNetworkStream.Write(integerBytes, 0, integerBytes.Length);
            // Write the contents
            clientNetworkStream.Write(fileBytes, 0, fileBytes.Length);
            Console.WriteLine("Send");
            // Wait for server to finish receiving
            clientNetworkStream.ReadByte();
            Console.WriteLine("Connection closed");
        }
        static string FileBase64Encoding(string path)
        {
            byte[] fileBytes = File.ReadAllBytes(path);
            string fileBase64String = Convert.ToBase64String(fileBytes);
            return fileBase64String;
        }
