	[SQLiteFunction(Name = "Sha1", Arguments = 1, FuncType = FunctionType.Scalar)]
	public class Sha1 : SQLiteFunction
	{
		public override object Invoke(object[] args)
		{
			var buffer = args[0] as byte[];
			if ( buffer == null )
			{
				var s = args[0] as string;
				if ( s != null )
					buffer = Encoding.Unicode.GetBytes(s);
			}
			if ( buffer == null )
				return null;
			using ( var sha1 = SHA1.Create() )
			{
				return sha1.ComputeHash(buffer);
			}
		}
	}
