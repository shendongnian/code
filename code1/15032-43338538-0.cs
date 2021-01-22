	static void Main( string[] args ) {
		const int max = 10000000;
		//
		//
		for ( int j = 0; j < 3; j++ ) {
			var sw = new Stopwatch();
			sw.Start();
			for ( int i = 0; i < max; i++ ) {
				var a = Environment.TickCount;
			}
			sw.Stop();
			Console.WriteLine( $"Environment.TickCount {sw.ElapsedMilliseconds}" );
			//
			//
			sw = new Stopwatch();
			sw.Start();
			for ( int i = 0; i < max; i++ ) {
				var a = DateTime.UtcNow.Ticks;
			}
			sw.Stop();
			Console.WriteLine( $"DateTime.UtcNow.Ticks {sw.ElapsedMilliseconds}" );
			//
			//
			sw = new Stopwatch();
			sw.Start();
			for ( int i = 0; i < max; i++ ) {
				var a = sw.ElapsedMilliseconds;
			}
			sw.Stop();
			Console.WriteLine( $"sw.ElapsedMilliseconds {sw.ElapsedMilliseconds}" );
		}
		Console.WriteLine( "Done" );
		Console.ReadKey();
	}
