		Dim types = (From t In Reflection.Assembly.GetAssembly(GetType(Int32)).GetTypes() Select t).Concat( _
					(From t In Reflection.Assembly.GetAssembly(GetType(Uri)).GetTypes() Select t))
		For Each t As Type In types
			If t.IsEnum AndAlso (From att In t.GetCustomAttributes(True) Where TypeOf (att) Is FlagsAttribute).Any() Then
				Console.WriteLine("Flag Enum: {0}", t.ToString())
			End If
		Next
		Console.ReadLine()
