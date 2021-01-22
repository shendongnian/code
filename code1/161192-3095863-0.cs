	<#@ template debug="false" hostspecific="true" language="C#" #>
	<#@ output extension=".csv" #>
	<#@ include file="T4Toolbox.tt" #>
	<#@ import namespace="EnvDTE" #>
	<#@ import namespace="System.Collections.Generic" #>
	<#
		List<CodeEnum> enums = GetEnums("TestClass.cs");	
		bool first = true;
		
		// Header
		foreach(CodeEnum e in enums)
		{
			if(first)
				first = false;
			else
				Write(",");
				
			Write(e.Name);
		}
		WriteLine("");
		
		// Data
		WriteData(enums);
	#>
	<#+
		private void WriteData(List<CodeEnum> enums)
		{
			WriteData(enums, new string[enums.Count], 0);
		}
		
		private void WriteData(List<CodeEnum> enums, string[] values, int level)
		{	
			foreach (CodeElement element in enums[level].Children)
			{
				values[level] = element.Name;
				
				if(level + 1 < enums.Count)
				{
					WriteData(enums, values, level + 1);
				}
				else
				{
					WriteLine(string.Join(",", values));
				}
			}
		}
		
		private List<CodeEnum> GetEnums(string enumFile)
		{
			ProjectItem projectItem = TransformationContext.FindProjectItem(enumFile);
			FileCodeModel codeModel = projectItem.FileCodeModel;
			return FindEnums(codeModel.CodeElements);
		}
		private List<CodeEnum> FindEnums(CodeElements elements)
		{
			List<CodeEnum> enums = new List<CodeEnum>();
			FindEnums(elements, enums);
			return enums.Count == 0
				? null
				: enums;
		}
		private void FindEnums(CodeElements elements, List<CodeEnum> enums)
		{
			foreach (CodeElement element in elements)
			{
				if (element is CodeEnum)
					enums.Add((CodeEnum)element);
				FindEnums(element.Children, enums);
			}
		}
	#>
