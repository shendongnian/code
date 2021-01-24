    public class Node<T> {
		public T Value { get; set; }
		
		private Node<T> _left;
		public Node<T> Left
		{
			set
			{ System.Console.WriteLine("setter called");_left = value; }
		}
		private Node<T> _right;
		public Node<T> Right
		{
			set
			{ System.Console.WriteLine("setter called"); _right = value; }
		}
		public Node(T value){
			Value = value;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Node<int> a = new Node<int>(1);
			Node<int> b = new Node<int>(3);
			a.Left = b;
			System.Console.ReadKey();
		}
	}
