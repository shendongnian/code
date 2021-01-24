    public class Myclass
    {
        public decimal MyProp { get; set; }
    }
    List<decimal> data = new List<decimal>() { 1,2,3,4,5};
    List<Myclass> myList = new List<Myclass>() { new Myclass(), new Myclass(), new Myclass()};
    data.Zip(myList, (dataItem, myListItem) => 
    {
        myListItem.MyProp = dataItem;
        return myListItem;
    }).ToList();
