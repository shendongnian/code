    <Project Sdk="Microsoft.NET.Sdk">
      <PropertyGroup>
        <OutputType>Exe</OutputType>
        <TargetFramework>net461</TargetFramework>
        <RuntimeIdentifier>win-x64</RuntimeIdentifier>
      </PropertyGroup>
      <ItemGroup>
        <PackageReference Include="Microsoft.ML.LightGBM" Version="0.3.0" />
      </ItemGroup>
      <ItemGroup>
        <None Update="iris-data.txt">
          <CopyToOutputDirectory>Always</CopyToOutputDirectory>
        </None>
      </ItemGroup>
    </Project>
