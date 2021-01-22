	<#@ template language="C#" #>
	<#@ output extension="cs" #>
	<#@ import namespace="System.Collections.Generic" #>
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Web;
	<# 
		String[] classNames = new String[] {"User","Project","Group","GroupUser","OperationSystem","TaskType","Priority","Severity","Status","Version","Platform","Task","TaskUser","Attachment","Comment","Setting"}; 
	#>
	namespace CamelTrap.Models
	{
	<# foreach(String className in classNames) { #>
		public partial class <#= className #> : IBasicEntityInfo
		{   
		}
	<# } #>
	}
