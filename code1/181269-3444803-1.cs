    public static class EnumTools
    {
    	public static string ToRawValueString(this Enum e)
    	{
    		return e
    			.GetType()
    			.GetFields(BindingFlags.Public | BindingFlags.Static)
    			.First(f=>f.Name==e.ToString())
    			.GetRawConstantValue()
    			.ToString();
    	}
    }
