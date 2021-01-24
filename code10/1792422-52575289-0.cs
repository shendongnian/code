	<#=Accessibility.ForType(container)#> partial class <#=code.Escape(container)#> : DbContext
	{
		public <#=code.Escape(container)#>()
			: base("name=<#=container.Name#>")
		{
	<#
