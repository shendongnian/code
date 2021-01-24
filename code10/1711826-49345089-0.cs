    class myClass
    {
        public int item;
        public string value;
        //ctor:
        public myClass(int item, string value) { this.item = item; this.value = value; }
    }
    static void updateList()
    {
        var listA = new List<myClass> { new myClass(1, "A1"), new myClass(2, "A2"), new myClass(3, "A3"), new myClass(4, "A4") };
        var listB = new List<myClass> { new myClass(1, "B1"), new myClass(4, "B4"), new myClass(2, "B2"), new myClass(5, "B5") };
        for (int i = 0; i < listB.Count; i++) //use index to be able to use RemoveAt which is faster
        {
            var b = listB[i];
            var j = listA.FindIndex(x => x.item == b.item);
            if (j >= 0) //A has this item, update its value
            {
                var v = listA[j].value;
                if (b.value != v) b.value = v;
            }
            else //A does not have this item
            {
                listB.RemoveAt(i);
            }
        }
        foreach (var a in listA)
        {
            //if (!listB.Contains(a)) listB.Add(a);
            if (!listB.Any(b => b.item == a.item)) listB.Add(a);
        }
    }
