List <Item> items;
public void LoadJsonAndReadToXML() {
  using(StreamReader r = new StreamReader(@ "E:\Json\overiddenhotelranks.json")) {
    string json = r.ReadToEnd();
    items = JsonConvert.DeserializeObject <List<Item>> (json);
    ReadToXML();
  }
}
And 
public void ReadToXML() {
  try {
    var xEle = new XElement("Items",
      from item in items select new XElement("Item",
        new XElement("mhid", item.mhid),
        new XElement("hotelName", item.hotelName),
        new XElement("destination", item.destination),
        new XElement("destinationID", item.destinationID),
        new XElement("rank", item.rank),
        new XElement("toDisplayOnFod", item.toDisplayOnFod),
        new XElement("comment", item.comment),
        new XElement("Destinationcode", item.Destinationcode),
        new XElement("LoadDate", item.LoadDate)
      ));
    xEle.Save("E:\\employees.xml");
    Console.WriteLine("Converted to XML");
  } catch (Exception ex) {
    Console.WriteLine(ex.Message);
  }
  Console.ReadLine();
}
I have used the class named Item to represent the elements
public class Item {
  public int mhid { get; set; }
  public string hotelName { get; set; }
  public string destination { get; set; }
  public int destinationID { get; set; }
  public int rank { get; set; }
  public int toDisplayOnFod { get; set; }
  public string comment { get; set; }
  public string Destinationcode { get; set; }
  public string LoadDate { get; set; }
}
It works....
