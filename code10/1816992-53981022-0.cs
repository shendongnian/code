    internal static class ConfigurationHelper
    {
    	internal static void ConfigureVarcharMax(PropertyBuilder<string> propertyBuilder, bool isRequired = true)
    	{
    		propertyBuilder
    			.IsRequired(isRequired)
    			//.HasColumnType("varchar(max)");
    			.HasColumnType("text");
    	}
    }
