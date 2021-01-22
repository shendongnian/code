    [XmlType("Providers")]
    public class Providers : List<Provider> { }
    public class Provider
    {
        public string ProviderType { get; set; }
        public string ProviderTitle { get; set; }
        public DeliveryRules DeliveryRules { get; set; }
        public ProviderConfiguration ProviderConfiguration { get; set; }
    }
    public class DeliveryRules
    {
        public bool PersonalDelivery { get; set; }
    }
    public class ProviderConfiguration
    {
        [XmlArrayItem("Address")]
        public string[] SendTo { get; set; }
    }
    public static void Main()
    {
        var serializer = new XmlSerializer(typeof (Providers));
        Providers providers;
        using (var stream = File.OpenRead("myfile.xml"))
        {
            providers = (Providers) serializer.Deserialize(stream);
        }
        foreach (var provider in providers)
        {
            Console.WriteLine(provider.ProviderTitle);
            foreach (var address in provider.ProviderConfiguration.SendTo)
            {
                Console.WriteLine("\t" + address);
            }
        }
    }
