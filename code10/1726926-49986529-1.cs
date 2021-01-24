    // here sortedlist1 will be sorted    
    var sortedlist1 = list1.OrderBy(x=>x.id = GetOrder(x.id));
 
    public int Getorder(int id)
    {
        return list2.Where(x=> x.id ==id).FirstOrDefault().SortedOrder;
    }
