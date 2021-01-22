	<#@ template debug="false" hostSpecific="true" language="C#" #>
	<#@ output extension=".cs" #>
	<#@ Assembly Name="System.Core.dll" #>
	<#@ import namespace="System.Linq" #> 
	<#@ import namespace="System.IO" #> 
	<#
		string GenWarning = "// THIS FILE IS GENERATED FROM " + Path.GetFileName(Host.TemplateFile) + " - ANY HAND EDITS WILL BE LOST!";
		const int MaxCases = 15;
	#>
	<#=GenWarning#>
	using System;
	public static class TypeSwitch
	{
	<# for(int icase = 1; icase <= MaxCases; ++icase) {
		var types = string.Join(", ", Enumerable.Range(1, icase).Select(i => "T" + i));
		var actions = string.Join(", ", Enumerable.Range(1, icase).Select(i => string.Format("Action<T{0}> action{0}", i)));
		var wheres = string.Join(" ", Enumerable.Range(1, icase).Select(i => string.Format("where T{0} : TV", i)));
	#>
		<#=GenWarning#>
		public static void On<TV, <#=types#>>(TV value, <#=actions#>)
			<#=wheres#>
		{
			if (value is T1) action1((T1)value);
	<# for(int i = 2; i <= icase; ++i) { #>
			else if (value is T<#=i#>) action<#=i#>((T<#=i#>)value);
	<#}#>
		}
	<#}#>
		<#=GenWarning#>
	}
