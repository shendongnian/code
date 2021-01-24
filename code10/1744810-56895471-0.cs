           public void VerticalOrderTraverse(BstNode root)
            {
                // Base case
                if (root == null)
                    return;
                // Create a map and store vertical oder in
                SortedDictionary<int, List<int>> dict = new SortedDictionary<int, List<int>>();     //used Sorted Dictionary
                int hd = 0;
                Queue<Tuple<BstNode, int>> que = new Queue<Tuple<BstNode, int>>();
                que.Enqueue(new Tuple<BstNode, int>(root, hd));
                while (que.Count != 0)
                {
                    Tuple<BstNode, int> temp = que.Peek();
                    que.Dequeue();
                    hd = temp.Item2;
                    BstNode node = temp.Item1;
                    if (dict.ContainsKey(hd))  //No need to try creating a new list, add it to the existing 
                        dict[hd].Add(node.data);
                    else
                    {
                        dict.Add(hd, new List<int>()); 
                        dict[hd].Add(node.data);
                    }
                    if (node.left != null)
                        que.Enqueue(new Tuple<BstNode, int>(node.left, hd - 1));
                    if (node.right != null)
                        que.Enqueue(new Tuple<BstNode, int>(node.right, hd + 1));
                }
               
                foreach (var item in dict)
                    foreach (var ite in item.Value)
                        Console.WriteLine(ite);
            }
        }
    }
}
