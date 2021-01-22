	public class PrioQueue
	{
		int total_size;
		SortedDictionary<int, Queue> storage;
		public PrioQueue ()
		{
			this.storage = new SortedDictionary<int, Queue> ();
			this.total_size = 0;
		}
		public bool IsEmpty ()
		{
			return (total_size == 0);
		}
		public object Dequeue ()
		{
			if (IsEmpty ()) {
				throw new Exception ("Please check that priorityQueue is not empty before dequeing");
			} else
				foreach (Queue q in storage.Values) {
					// we use a sorted dictionary
					if (q.Count > 0) {
						total_size--;
						return q.Dequeue ();
					}
				}
				Debug.Assert(false,"not supposed to reach here. problem with changing total_size");
				return null; // not supposed to reach here.
		}
		// same as above, except for peek.
		public object Peek ()
		{
			if (IsEmpty ())
				throw new Exception ("Please check that priorityQueue is not empty before dequeing");
			else
				foreach (Queue q in storage.Values) {
					if (q.Count > 0)
						return q.Peek ();
				}
				Debug.Assert(false,"not supposed to reach here. problem with changing total_size");
				return null; // not supposed to reach here.
			
		}
		public object Dequeue (int prio)
		{
			total_size--;
			return storage[prio].Dequeue ();
		}
		public void Enqueue (object item, int prio)
		{
			if (!storage.ContainsKey (prio)) {
				storage.Add (prio, new Queue ());
				Enqueue (item, prio);
				// run again
			} else {
				storage[prio].Enqueue (item);
				total_size++;
			}
		}
	}
}
