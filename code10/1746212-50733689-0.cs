    <Project Sdk="Microsoft.NET.Sdk.Web">
    <PropertyGroup>
        <TargetFramework>netcoreapp2</TargetFramework>
 
    </PropertyGroup>
    
    
    <ItemGroup>             
    <PackageReference Include=
    "Microsoft.AspNetCore.All" Version="2.0.3" />
    <PackageReference Include=
    "Microsoft.AspNetCore.Cors" Version="2.0.3" />                  
    <PackageReference Include=
    "Microsoft.EntityFrameworkCore.SqlServer" Version="2.0.3" />                            
    <PackageReference Include=
    "Microsoft.EntityFrameworkCore.Tools" Version="2.0.3" PrivateAssets="All" />       
    <PackageReference Include=
    "Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="2.0.4" PrivateAssets="All" />
    </ItemGroup>  
         
    <ItemGroup>                      
    <DotNetCliToolReferenceInclude=
        "Microsoft.EntityFrameworkCore.Tools.DotNet"Version="2.0.3" />   
    <DotNetCliToolReferenceInclude=
        "Microsoft.VisualStudio.Web.CodeGeneration.Tools" Version="2.0.4" /> 
    <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.3" />       
    </ItemGroup>
