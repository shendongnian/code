    <Project Sdk="Microsoft.NET.Sdk">
      <PropertyGroup>
        <TargetFramework>netcoreapp2.1</TargetFramework>
        <RuntimeFrameworkVersion>2.1.0</RuntimeFrameworkVersion> --> fix publishing issues
        <PlatformTarget>AnyCPU</PlatformTarget> --> fix publishing issues
      </PropertyGroup>
      <ItemGroup>
        <PackageReference Update="Microsoft.NETCore.App" Version="2.1.0" /> --> fix building issues
        <ProjectReference Include="..\PublicSonar.Monitor.Persistent.Json\PublicSonar.Monitor.Persistent.Json.csproj" />
      </ItemGroup>
    </Project>
