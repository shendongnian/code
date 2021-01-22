    public class FavouriteList
    {
       [XmlIgnore]
       public string Name; // this name will be "Customer" and "Supplier"
       [XmlElement("ID")]
       public List<int> aList; // to store those "ID" value
    }
    
    public class FavouriteSettings
    {
       [XmlIgnore]
       public List<FavouriteList> bigList;
       [XmlElement("Customer")]
       public FavouriteList[] Customers
       {
           get { return bigList.Where(fl => fl.Name == "Customer").ToArray(); }
           set { bigList.AddRange(value); }
       }
       [XmlElement("Supplier")]
       public FavouriteList[] Suppliers
       {
           get { return bigList.Where(fl => fl.Name == "Supplier").ToArray(); }
           set { bigList.AddRange(value); }
       }
    }
