    public class Order
    {
        // same data properties as earlier code sample
        public static List<Order> GenerateFromRawDataLines(List<List<string>> rawData)
        {
            // do a linq GroupBy on rawData's orderID column
            // for each item in the GroupBy:
                // generate a new Order instance, populate its data members
                // for each item in the subgrouping:
                    // add a new Item instance with an embedded Address instance.
        }
    }
    public class Item
    {
        // same data properties as earlier code sample
        public Item(List<string> rawDataLine)
        {
            this.itemID = rawDataLine[3];
            this.name = rawDataLine[4];
            // etc - translating a raw List<string> of data values into a class instance
        }
    }
