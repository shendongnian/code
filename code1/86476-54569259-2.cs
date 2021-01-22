            var dictionary = new Dictionary<string, string>() {
                { "{", "}" },
                {"[", "]" },
                {"(",")" }
            };
            var par = "{()}";
            var queue = new Queue();
            var stack = new Stack();
            bool isBalanced = true;
            var size = par.ToCharArray().Length;
            if(size % 2 != 0)
            {
                isBalanced = false;
            }
            else
            {
                foreach (var c in par.ToCharArray())
                {
                    stack.Push(c.ToString());
                    queue.Enqueue(c.ToString());
                }
                while (stack.Count > size/2 && queue.Count > size/2)
                {
                    var a = (string)queue.Dequeue();
                    var b = (string)stack.Pop();
                    if (dictionary.ContainsKey(a) && b != dictionary[a])
                    {
                        isBalanced = false;
                    }
                }
            }
            Console.WriteLine(isBalanced?"balanced!":"Not Balanced");
            Console.ReadLine();
