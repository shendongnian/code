    void Main()
    {
    	var xml = @"<Project Sdk=""Microsoft.NET.Sdk.Web"">
    	  <PropertyGroup>
    	    <TargetFramework>net47</TargetFramework>
    	    <OutputType>Exe</OutputType>
    	    <GenerateAssemblyTitleAttribute>true</GenerateAssemblyTitleAttribute>
    	    <GenerateAssemblyDescriptionAttribute>true</GenerateAssemblyDescriptionAttribute>
    	  </PropertyGroup>
    	  <ItemGroup>
    	    <PackageReference Include=""Microsoft.AspNetCore"" Version=""2.1.2"" />
    	    <PackageReference Include=""Microsoft.AspNetCore.Authentication.Cookies"" Version=""2.1.1"" />
    	    <PackageReference Include=""Microsoft.AspNetCore.Authentication.JwtBearer"" Version=""2.1.1"" />
    	  </ItemGroup>
    	</Project>";
    
    	var doc = XDocument.Parse(xml);
    	var packageReferences = doc.XPathSelectElements("//PackageReference")
    		.Select(pr => new PackageReference
    		{
    			Include = pr.Attribute("Include").Value,
    			Version = new Version(pr.Attribute("Version").Value)
    		});
    
    	Console.WriteLine($"Project file contains {packageReferences.Count()} package references:");
    	foreach (var packageReference in packageReferences)
    	{
    		Console.WriteLine($"{packageReference.Include}, version {packageReference.Version}");
    	}
    
    	// Output:
    	// Project file contains 3 package references:
    	// Microsoft.AspNetCore, version 2.1.2
    	// Microsoft.AspNetCore.Authentication.Cookies, version 2.1.1
    	// Microsoft.AspNetCore.Authentication.JwtBearer, version 2.1.1
    }
    
    public class PackageReference
    {
    	public string Include { get; set; }
    	public Version Version { get; set; }
    }
