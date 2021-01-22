    class Foo
    {
        public List<Foo> Reachables { get; set; }
        public Foo()
        {
            this.Reachables = new List<Foo>();
        }
        public bool Add(Foo other)
        {
            this.Reachables.Add(other); // add it 
            if(other.IsReachable(this)) // then see if it create a cycle
            {
                this.Reachables.Remove(other); // if yes remove it
                return false;
            }
            else
            {
                return true; // else keep it 
            }
        }
        private bool IsReachable(Foo goal) 
        {
            // BFS 
	        Queue<Foo> nextQueue = new Queue<Foo>();
	        List<Foo> traversed = new List<Foo>();
 
	        bool found = false;
 
	        nextQueue.Enqueue(this);
         
	        while (!found) {
                Foo node = null;
                try { node = nextQueue.Dequeue(); }
                catch { break; }
		        traversed.Add(node);
         
		        if (node.Equals(goal)) {
			        found = true;
			        break;
		        } 
		        else 
                {
			        foreach (Foo neighbor in node.Reachables)
                        if (!traversed.Contains(neighbor) && !nextQueue.Contains(neighbor)) 
					        nextQueue.Enqueue(neighbor);
		        }
	        }
	        return found;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Foo A = new Foo();
            Foo B = new Foo();
            Foo C = new Foo();
            Console.WriteLine(C.Add(B));
            Console.WriteLine(B.Add(A));
            Console.WriteLine(A.Add(C));
            Console.WriteLine(C.Add(A));
                                       
        }
    }
