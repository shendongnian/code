    public class Program
    {
    	public static async Task Main( String[] args )
    	{
    		var foo = new Foo();
    
    		var sw = Stopwatch.StartNew();
    		
    		await foo.Start();
    
    		sw.Stop();
    
    		Console.WriteLine($"Elapsed {sw.Elapsed} {sw.ElapsedMilliseconds}ms");
    		Console.ReadLine();
    	}
    }
    
    public class Foo
    {
    	public async Task CacheInitialize( IList<Location> locations, CancellationToken token ) =>
    		await SecondInitialize( locations, token )
    			.ConfigureAwait( false );
    
    	public async Task<TripLength> Calculate( Location start, Location finish, CancellationToken token )
    	{
    		if ( start == finish )
    			return TripLength.Zero;
    
    		var parameters = new RouteParameters
    		{
    			Coordinates = new[]
    			{
    				new Coordinate( start.Latitude, start.Longitude ),
    				new Coordinate( finish.Latitude, finish.Longitude )
    			}
    		};
    
    		var route = await RunRoute( parameters, token );
    
    		return new TripLength();
    	}
    
    	public async Task SecondInitialize( IList<Location> locations, CancellationToken token )
    	{
    		var tasks = new List<Task>( locations.Count );
    
    		foreach ( var outer in locations )
    		foreach ( var inner in locations )
    		{
    			if ( inner.Equals( outer ) )
    				continue;
    
    			tasks.Add( Calculate( outer, inner, token ) );
    		}
    
    		await Task.WhenAll( tasks );
    	}
    
    	public async Task Start()
    	{
    		var locations = new List<Location>();
    		await CacheInitialize( locations, CancellationToken.None )
    			.ConfigureAwait( false );
    	}
    
    	protected async Task<RouteResult> RunRoute( RouteParameters routeParams, CancellationToken token )
    	{
    		return await Task
    					 .Run( () =>
    						   {
    							   //RouteResult routeResults;
    							   //var status = _routeService.Route( routeParams, out routeResults );
    							   //return routeResults;
    							   return new RouteResult();
    						   },
    						   token )
    					 .ConfigureAwait( false );
    	}
    }
    
    public class Coordinate
    {
    	public Double Latitude { get; }
    	public Double Longitude { get; }
    	public Coordinate( Double latitude, Double longitude )
    	{
    		Latitude = latitude;
    		Longitude = longitude;
    	}
    }
    public class RouteParameters
    {
    	public Coordinate[] Coordinates { get; set; }
    }
    public class TripLength
    {
    	public static TripLength Zero = new TripLength();
    }
    public class RouteResult
    {
    }
    public class Location
    {
    	public Double Latitude { get; }
    	public Double Longitude { get; }
    }
