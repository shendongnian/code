    void Main()
    {
	     ICollection<EnumValueDto> list = EnumValueDto.ConvertEnumToList<SearchDataType>();
	     foreach (var element in list)
	     {
		    Console.WriteLine(string.Format("Key: {0}; Value: {1}", element.Key, element.Value));
	     }
	 
	     /* OUTPUT:
		    Key: 1; Value: Boolean
		    Key: 2; Value: DateTime
		    Key: 3; Value: Numeric		   
	     */
    }
    public class EnumValueDto
    {
	    public int Key { get; set; }
	    public string Value { get; set; }
	    public static ICollection<EnumValueDto> ConvertEnumToList<T>() where T : struct, IConvertible
	    {
		    if (!typeof(T).IsEnum)
		    {
		   	    throw new Exception("Type given T must be an Enum");
		    }
            var result = Enum.GetValues(typeof(T))
                             .Cast<T>()
                             .Select(x =>  new EnumValueDto { Key = Convert.ToInt32(x), 
                                           Value = x.ToString(new CultureInfo("en")) })
                             .ToList()
                             .AsReadOnly();
		    return result;
	    }
    }
    public enum SearchDataType
    {
	    Boolean = 1,
	    DateTime,
	    Numeric
    }
