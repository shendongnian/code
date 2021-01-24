    var lstVendorList = (from i in colVendorList.AsEnumerable<SP.ListItem>()
                         select new Vendor
                         {
                             Title = i["Title"],
                             ID = i["ID"]
                         });
    public class Vendor
    {
        public string Title { get; set; }
        public string ID { get; set; }
    }
