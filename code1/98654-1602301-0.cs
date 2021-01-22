    [Serializable]
    private class Cereal : ISerializable
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public Cereal()
    	{
    	}
    	protected Cereal( SerializationInfo info, StreamingContext context)
    	{
    		Id = info.GetInt32 ( "Id" );
    		Name = info.GetString ( "Name" );
    	}
    	public void GetObjectData( SerializationInfo info, StreamingContext context )
    	{
    		info.AddValue ( "Id", Id );
    		info.AddValue ( "Name", Name );
    	}
    }
