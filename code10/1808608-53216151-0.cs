    <#@ template debug="true" hostspecific="true" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ assembly name="System.Windows.Forms" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Text" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="System.IO" #>
    <#@ output extension=".cs" #>
    
    using System.Windows.Forms;
    using System.Collections.Generic;
    
    namespace Sandbox
    {
    	public class TestClass
    	{
    	  public static List<string> GetFiles()
    	  {
    		  List<string> filenames = new List<string>();
    		  <#
    		  string path = @"C:\Test";
    		  foreach (var x in Directory.GetFiles(path))
    		  {#>
    			filenames.Add(@"<#=x#>");
    		  <#}#>
    		  return filenames;
    
    	  }
    	}
    }
