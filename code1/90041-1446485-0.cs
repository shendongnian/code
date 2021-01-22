	readonly ObjectSerializer _serializer;
	public MyForm()
	{
		_serializer = new ObjectSerializer(this,
			"Top", "Left", "Height", "Width",
			"_splitter.SplitterDistance");
		_serializer.ContinueOnError = true;
	}
	private void Form_Load(object sender, EventArgs e)
	{
		_serializer.Deserialize(new CSharpTest.Net.Serialization.StorageClasses.UserSettingStorage());
	}
	void Form_Closing(object sender, FormClosingEventArgs e)
	{
		_serializer.Serialize(new CSharpTest.Net.Serialization.StorageClasses.UserSettingStorage());
	}
