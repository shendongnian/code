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
