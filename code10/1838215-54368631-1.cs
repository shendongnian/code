     var itemList1 = new List<Class1>();
     var itemList2 = new List<Class2>();
     var item1 = new Class1();
     var item2 = new Class2(item1);
     itemList1.Add(item1);
     itemList2.Add(item2);
     //you could put this in a method and do it as a single operation:
     itemList1.Remove(item1);
     itemList2.RemoveAll(i => i.Item == item1);
