    <Project Sdk="Microsoft.NET.Sdk.Razor">
      <PropertyGroup>
        <TargetFrameworks>netstandard2.0</TargetFrameworks>
      </PropertyGroup>
      <ItemGroup>
        <PackageReference Include="Microsoft.AspNetCore.Mvc" Version="2.1.3" />
      </ItemGroup>
      <ItemGroup>
        <ProjectReference Include="path-to-yourview-models-project.csproj" />
          --maybe other project refs here
      </ItemGroup>
    </Project>
