	class Panda : IDisposable
	{
		public static int population = 0;
		public string _name;
	
		public Panda( string name )
		{
			if( name == null )
				throw new ArgumentNullException( name );
			
			_name = name;
			population++;
		}
		protected virtual void Dispose( bool disposing )
		{
			if( disposing && name != null )
			{
				population--;
				name = null;
			}
		}
	
		public void Dispose()
		{
			Dispose( true );
			GC.SuppressFinalize( this );
		}
	
		~Panda(){ Dispose( false ); }
	}
