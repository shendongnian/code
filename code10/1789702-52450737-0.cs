    <Project Sdk="Microsoft.NET.Sdk.Web">
    
      <PropertyGroup>
        <TargetFramework>netcoreapp2.1</TargetFramework>
    	<PublishWithAspNetCoreTargetManifest>false</PublishWithAspNetCoreTargetManifest>
    	<DockerComposeProjectPath>..\docker-compose.dcproj</DockerComposeProjectPath>
      </PropertyGroup>
    
      <ItemGroup>
        <Compile Remove="wwwroot\**" />
        <Content Remove="wwwroot\**" />
        <EmbeddedResource Remove="wwwroot\**" />
        <None Remove="wwwroot\**" />
      </ItemGroup>
    
      <ItemGroup>
        ...
      </ItemGroup>
    
      <ItemGroup>
        <PackageReference Include="Microsoft.AspNetCore.App" Version="2.1.4" />
        <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="2.1.2" />
        <PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="2.1.4" />
        ...
      </ItemGroup>
    
      ...
    
    </Project>
