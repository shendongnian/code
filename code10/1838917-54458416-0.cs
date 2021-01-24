    for (int i = 0; i < 3 ; i++)
    {
        Task.Factory.StartNew(() => 
        {
            Console.WriteLine($"Spawning task: {Task.CurrentId}");
            semaphore.Wait(); //CurrentCount--
            Console.WriteLine($"Executing task: {Task.CurrentId}");
        });
    }
   
    
    while (semaphore.CurrentCount <= 2)
    {
        Console.ReadKey();
        Console.WriteLine("Key pressed");
        semaphore.Release(1); //CurrentCount++
    }
