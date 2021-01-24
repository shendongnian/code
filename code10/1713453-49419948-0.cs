    var orders = new List<int> { 4, 5, 6, 0, 1, 2, 3 };
    var nums = new List<int> {2, 5, 6, 2, 2, 4};
                var queue = new Queue<int>(nums);
                var results = new List<List<int>>();
                while (queue.Count > 0)
                {
                    var subLists = new List<int>();
                    foreach (var order in orders)
                    {
                        if(order == queue.Peek())
                            subLists.Add(queue.Dequeue());
                        if (queue.Count == 0)
                            break;
                    }
                    results.Add(subLists);
                }
