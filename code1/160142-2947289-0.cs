	public class Vertex3d
	{
		//fields are all declared private, which is a good practice in general 
		private int _x; 
		
		//The properties are declared public, but could also be private, protected, or protected internal, as desired.
		public int X
		{ 
			get { return _x; } 
			set { _x = value; } 
		}
	}
