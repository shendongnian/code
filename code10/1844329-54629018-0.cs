    var Name_ID_YOB = new List<Tuple<string, int, int>>(); // YOB is year of birth
    for (int i = 0; i < 10; i++)
    {
    	Name_ID_YOB.Add(new Tuple<string, int, int>("Name", i, 1998 + i));
    }
    Queue MyQueue = new Queue();
    foreach (var tuple in Name_ID_YOB)
    {
    	MyQueue.Enqueue(tuple);
    }
    int Total = MyQueue.Count; // Total Item In Queue
    while (MyQueue.Count > 0)
    {
    	var NAMEIDYOB = MyQueue.Dequeue() as Tuple<string, int, int>;
    	Console.WriteLine($"[Console] {NAMEIDYOB}");
    	Console.WriteLine($"[Console] {NAMEIDYOB.Item1}"); // Expected to print Name
    	Console.WriteLine($"[Console] {NAMEIDYOB.Item2}"); // Expected to print ID
    	Console.WriteLine($"[Console] {NAMEIDYOB.Item3}"); // Expected to print YOB
    }
    Console.WriteLine("Dequeue Done");
    Console.ReadLine();
