    public byte[] Icon()
	{
		var assembly = System.Reflection.Assembly.GetExecutingAssembly();
		byte[] buffer = null;
		using (var stream = assembly.GetManifestResourceStream("MyPlugin.icon.png"))
		{
			buffer = new byte[stream.Length];
			stream.Read(buffer, 0, buffer.Length);
		}
		return buffer;
	}
