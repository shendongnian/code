    <#@ template debug="false" hostspecific="true" language="C#" #>
    <#@ output extension=".generated.cs" #>
    namespace MyNamespace
    {
    	public static class BuildVariables
    	{
    		public static readonly string SolutionDir = <#= QuotedString(Host.ResolveAssemblyReference(@"$(SolutionDir)")) #>;
    	}
    }
    <#+
    public string QuotedString(string value)
    {
    	if (value == null)
    	{
    		return "null";
    	}
    
    	return "@\"" + value.Replace("\"", "\"\"") + "\"";
    }
    #>
