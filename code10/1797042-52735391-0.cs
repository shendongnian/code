	class Program
	{
		static void Main( string[] args )
		{
			var transformBlock = new TransformBlock<int, int>( x =>
			{
				Thread.Sleep( x );
				return x;
			}, new ExecutionDataflowBlockOptions {EnsureOrdered = false, MaxDegreeOfParallelism = 10} );
			var actionBlock = new ActionBlock<int>( x => Console.WriteLine( x ) );
			transformBlock.LinkTo( actionBlock, new DataflowLinkOptions {PropagateCompletion = true});
			for( var i = 9; i > 0; i-- )
				transformBlock.Post( i * 1000 );
			transformBlock.Complete();
			actionBlock.Completion.Wait();
			Console.ReadLine();
		}
	}
