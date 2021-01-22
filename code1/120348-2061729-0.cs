    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Console.WriteLine("Testing serialization");
                DataContractSerializer formatter = new DataContractSerializer(typeof(Junk));
                MemoryStream stream = new MemoryStream();
                Junk junk = new Junk();
                junk.Name = "Junk";
                junk.Value = 15;
                formatter.WriteObject(stream, junk);
                Console.WriteLine("Wrote object to stream");
                stream.Seek(0, SeekOrigin.Begin);
                Junk savedJunk = formatter.ReadObject(stream) as Junk;
                Console.WriteLine("Deserialized name = {0}", savedJunk.Name);
                Console.WriteLine("Deserialized value = {0}", savedJunk.Value);
                Console.WriteLine("Testing complete");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
    [DataContract]
    class Junk
    {
        [DataMember]
        public string Name = "";
        [DataMember]
        public int Value = 0;
    }
