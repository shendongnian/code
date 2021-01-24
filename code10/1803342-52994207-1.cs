    public class Rootobject
    {
      public string invoiceNumber { get; set; }
      public DateTime invoiceDate { get; set; }
      public int invoiceValue { get; set; }
      public object remarks { get; set; }
      public Item[] items { get; set; }
    }
    public class Item
    {
      public string gRNNo { get; set; }
      public int itemCode { get; set; }
      public string itemDesc { get; set; }
      public string qty { get; set; }
    }
    Rootobject purHeader = JsonConvert.DeserializeObject<Rootobject>(data.ToString());
