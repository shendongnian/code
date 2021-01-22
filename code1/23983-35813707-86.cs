    #@ template debug="false" hostspecific="true" language="C#" #>
	<#@ assembly name="System.Core" #>
	<#@ assembly name="System.Windows.Forms" #>
	<#@ import namespace="System.Linq" #>
	<#@ import namespace="System.Text" #>
	<#@ import namespace="System.Collections.Generic" #>
	<#@ import namespace="System.Resources" #>
	<#@ import namespace="System.Collections" #>
	<#@ import namespace="System.IO" #>
	<#@ import namespace="System.ComponentModel.Design" #>
	<#@ output extension=".xml" #>
	<#
	var fileName = "../Resources/Resources.en.resx";
	var fileResultName = "../T4/CreateAppLocalizationEN.xml";
	var fileResultRexPath = Path.Combine(Path.GetDirectoryName(this.Host.ResolvePath("")), "MyProject.Language", fileName);
	var fileResultPath = Path.Combine(Path.GetDirectoryName(this.Host.ResolvePath("")), "MyProject.Language", fileResultName);
		var fileNameDest = "strings.xml";
		var pathBaseDestination = Directory.GetParent(Directory.GetParent(this.Host.ResolvePath("")).ToString()).ToString();
		var currentPathDest =pathBaseDestination + "/MyProject.App.AndroidApp/Resources/values-en/" + fileNameDest;
		using(var reader = new ResXResourceReader(fileResultRexPath))
		{
			reader.UseResXDataNodes = true;
			#>
			<resources>
			<#
					foreach(DictionaryEntry entry in reader)
					{
						var name = entry.Key;
						//if(!name.ToString().Contains("WEBSHOP_") && !name.ToString().Contains("DASHBOARD_"))//only include keys with these prefixes, or the country ones.
						//{
						//	if(name.ToString().Length != 2)
						//	{
						//		continue;
						//	}
						//}
						var node = (ResXDataNode)entry.Value;
						var value = node.GetValue((ITypeResolutionService) null); 
						 if (!String.IsNullOrEmpty(value.ToString())) value = value.ToString().Replace("\n", "");
						 if (!String.IsNullOrEmpty(value.ToString())) value = value.ToString().Replace("\r", "");
						 if (!String.IsNullOrEmpty(value.ToString())) value = value.ToString().Replace("&", "&amp;");
						 if (!String.IsNullOrEmpty(value.ToString())) value = value.ToString().Replace("<<", "");
						 //if (!String.IsNullOrEmpty(value.ToString())) value = value.ToString().Replace("'", "\'");
	#>
				  <string name="<#=name#>">"<#=value#>"</string>
	<#		
					}
	#>
				<string name="WEBSHOP_LASTELEMENT">just ignore this</string>
	<#
			#>
			</resources>
			<#
			File.Copy(fileResultPath, currentPathDest, true);
		}
	#>
