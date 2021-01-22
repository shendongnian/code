	namespace GenLinkedList
	{
		class Program
		{
			static void Main(string[] args)
			{
				GenericList<object> list = new GenericList<object>();
				// Add items to list.
				list.AddHead("some string here");
				list.AddHead(DateTime.Today.ToLongDateString());
				list.AddHead(13);
				list.AddHead(13.005);
				for (int x = 0; x < 10; x++)
				{
					list.AddHead(x);
				}
				// Enumerate list.
				foreach (object i in list)
				{
					Console.WriteLine(i + " " + i.GetType());
				}
				Console.WriteLine("\nDone");
			}
		}
	}
	
	namespace GenLinkedList
	{
		// type parameter T in angle brackets
		class GenericList<T>
		{
			// The nested class is also generic on T.
			public class Node
			{
				private Node next;
				// T as private member data type.
				private T data;
				// T used in non-generic constructor.
				public Node(T t)
				{
					next = null;
					data = t;
				}
				public Node Next
				{
					get { return next; }
					set { next = value; }
				}
				public T Data
				{
					get { return data; }
					set { data = value; }
				}
			}
			private Node head;
			// constructor
			public GenericList()
			{
				head = null;
			}
			// T as method parameter type
			public void AddHead(T t)
			{
				Node n = new Node(t);
				n.Next = head;
				head = n;
			}
			public IEnumerator<T> GetEnumerator()
			{
				Node current = head;
				while (current != null)
				{
					yield return current.Data;
					current = current.Next;
				}
			}
		}
	}
