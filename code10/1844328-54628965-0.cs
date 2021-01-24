    while (MyQueue.Count > 0)
    {
        var NAMEIDYOB = MyQueue.Dequeue();
        Console.WriteLine($"[Console] {NAMEIDYOB}");
        Console.WriteLine($"[Console] {NAMEIDYOB.Item1}"); // Expected to print Name
        Console.WriteLine($"[Console] {NAMEIDYOB.Item2}"); // Expected to print ID
        Console.WriteLine($"[Console] {NAMEIDYOB.Item3}"); // Expected to print YOB
     }
