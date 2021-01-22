            var par = "{()}";
            var queue = new Queue();
            var stack = new Stack();
            foreach(var c in par.ToCharArray())
            {
                stack.Push(c);
                queue.Enqueue(c);
            }
            while (stack.Count > 0 && queue.Count > 0)
            {
                var a = stack.Pop();
                var b = queue.Dequeue();
                // do something with a and b here ....
            }
