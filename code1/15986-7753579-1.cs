	public interface IColor
	{
		byte Red   {get;}
		byte Green {get;}
		byte Blue  {get;}
		// compiler generates anonymous extension class
		public static byte Luminance(this IColor c)     
		{
			return (byte)(c.Red*0.3 + c.Green*0.59+ c.Blue*0.11);
		}
	}
	
