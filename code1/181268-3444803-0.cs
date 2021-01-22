    public static class EnumTools
    {
    	public static string ToRawValueString(this Enum e)
    	{
    		return e
    			.GetType()
    			.GetFields(BindingFlags.Public | BindingFlags.Static)
    			.Where(f=>f.Name==e.ToString())
    			.Select(f=>f.GetRawConstantValue())
    			.Single()
    			.ToString();
    	}
    }
