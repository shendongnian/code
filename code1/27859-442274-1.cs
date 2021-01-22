    	//prepare expected list of objects that want to be tested
            List<MyObject> list = new List<MyObject>();
            list.Add(new MyObject() {BookingNo="111",...});
            list.Add(new MyObject() {BookingNo="111",...});
            // grouping objects in list
            IEnumberable<IGrouping<string, MyObject>> group = list.GroupBy(p => p.BookingNo);
	//in my test method
	myReturnObj  obj = MethodA(group.First());
	Assert.xx(...);
