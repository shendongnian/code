    // Getting types/methods
    var itemType = typeof(double);
    var repeatMethod = typeof(Enumerable).GetMethod(nameof(Enumerable.Repeat)).MakeGenericMethod(itemType);
    
    var queueType = typeof(Queue<>).MakeGenericType(itemType);
    var queueCtor = queueType.GetConstructor(new[] { typeof(IEnumerable<>).MakeGenericType(itemType) });
    
    // Build the Func<>
    var repeatCall = Expression.Call(repeatMethod, Expression.Constant(Convert.ChangeType(100, itemType)), Expression.Constant(1, typeof(int)));
    var ctorCall = Expression.New(queueCtor, repeatCall);
    
    var lambda = Expression.Lambda<Func<Queue<double>>>(ctorCall);
    var func = lambda.Compile();
    
    // Call it :-)
    var queue = func();
    
    Console.WriteLine(queue.Count);
    Console.WriteLine(queue.Dequeue());
