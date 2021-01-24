    public class DateTimeNullableSerializer : IBsonSerializer
    {
    	public Type ValueType { get; }
    	private DateTimeSerializer dateTimeSerializer;
    	/// <summary>
    	/// Initializes a new instance of the <see cref="T:DateTimeNullableSerializer" /> class.
    	/// </summary>
    	public DateTimeNullableSerializer()
    	{
    		ValueType = typeof(DateTime?);
    		dateTimeSerializer = new DateTimeSerializer(DateTimeKind.Utc, BsonType.DateTime);
    	}
    
    	/// <summary>
    	/// Initializes a new instance of the <see cref="T:DateTimeNullableSerializer" /> class.
    	/// </summary>
    	/// <param name="dateOnly">if set to <c>true</c> [date only].</param>
    	public DateTimeNullableSerializer(bool dateOnly)
    	{
    		ValueType = typeof(DateTime?);
    		dateTimeSerializer = new DateTimeSerializer(dateOnly);
    	}
    
    	/// <summary>
    	/// Initializes a new instance of the <see cref="T:DateTimeNullableSerializer" /> class.
    	/// </summary>
    	/// <param name="dateOnly">if set to <c>true</c> [date only].</param>
    	/// <param name="representation">The representation.</param>
    	public DateTimeNullableSerializer(bool dateOnly, BsonType representation)
    	{
    		ValueType = typeof(DateTime?);
    		dateTimeSerializer = new DateTimeSerializer(dateOnly, representation);
    	}
    
    	/// <summary>
    	/// Initializes a new instance of the <see cref="T:DateTimeNullableSerializer" /> class.
    	/// </summary>
    	/// <param name="representation">The representation.</param>
    	public DateTimeNullableSerializer(BsonType representation)
    	{
    		ValueType = typeof(DateTime?);
    		dateTimeSerializer = new DateTimeSerializer(DateTimeKind.Utc, representation);
    	}
    
    	/// <summary>
    	/// Initializes a new instance of the <see cref="T:DateTimeNullableSerializer" /> class.
    	/// </summary>
    	/// <param name="kind">The kind.</param>
    	public DateTimeNullableSerializer(DateTimeKind kind)
    	{
    		ValueType = typeof(DateTime?);
    		dateTimeSerializer = new DateTimeSerializer(kind, BsonType.DateTime);
    	}
    
    	/// <summary>
    	/// Initializes a new instance of the <see cref="T:DateTimeNullableSerializer" /> class.
    	/// </summary>
    	/// <param name="kind">The kind.</param>
    	/// <param name="representation">The representation.</param>
    	public DateTimeNullableSerializer(DateTimeKind kind, BsonType representation)
    	{
    		ValueType = typeof(DateTime?);
    		dateTimeSerializer = new DateTimeSerializer(kind, representation);
    	}
    
    	public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    	{
    		if (context.Reader.CurrentBsonType == BsonType.Null)
    		{
    			context.Reader.ReadNull();
    			return null;
    		}
    
    		return dateTimeSerializer.Deserialize(context, args);
    	}
    
    	public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
    	{
    		if (value is null)
    			context.Writer.WriteNull();
    		else
    			dateTimeSerializer.Serialize(context, args, (DateTime)value);
    	}
    }
