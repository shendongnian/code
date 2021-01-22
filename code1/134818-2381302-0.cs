    // dummy initialization
            System.Collections.Generic.Queue<int> queue = new Queue<int>();
            for (int i = 0; i < 7; ++i ) { queue.Enqueue(i); }// add each element at the end of the container
            // working thread
            if (queue.Count > 0)
                doSomething(queue.Dequeue());// removes the last element of the container and calls doSomething on it
