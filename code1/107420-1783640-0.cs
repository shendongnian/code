    foreach ( var iface in type.GetInterfaces() )
	{
	  foreach ( var prop in iface.GetProperties() )
	  {
		Console.WriteLine( iface.Name +"-"+ prop.Name );
	  }
	}
