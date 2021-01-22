    BeginInvoke(new Action(()=>Console.WriteLine("BeginInvoke")));
    Console.WriteLine("AfterBeginInvokeCalled");
    
    Invoke(new Action(()=>Console.WriteLine("Invoke")));
    Console.WriteLine("AfterInvokeCalled");
