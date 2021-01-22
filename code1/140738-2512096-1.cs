      arrays arr = new arrays();
            arr.PriorityQueue = new List<element>(
                new [] { 
                    new element {node = 1, priority =2 }, 
                    new element { node = 2, priority = 10}
                    //..
                    //..
                });
    
    
            arrays arr2 = new arrays();
            arr2.PriorityQueue = new List<element>(
                arr.PriorityQueue
                );
    
    
            arrays arr3 = new arrays();
            arr3.PriorityQueue = new List<element>(arr2.PriorityQueue.FindAll(z => (1 == 1)));
    
    
            arrays arr4 = new arrays();
            arr4.PriorityQueue = new List<element>(arr3.PriorityQueue.ToArray());
