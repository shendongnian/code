    class Program
    {
        static void Main(string[] args)
        {
            var channelSettings = new ChannelSettings();
            channelSettings.attachments = new AttachSettings();
            channelSettings.attachments.fallback = "test";
    
            var testSerialize = JsonConvert.SerializeObject(channelSettings);
            dynamic testDeserialize = JsonConvert.DeserializeObject<dynamic>(testSerialize);
            Console.WriteLine(testDeserialize.attachments.fallback); // here you can access the parameters
        }
    }
    public class ChannelSettings
    {
        public string channel { get; set; }
        public string username { get; set; }
        public string text { get; set; }
        public dynamic attachments { get; set; } //Here i would like to this property was dynamic
    }
