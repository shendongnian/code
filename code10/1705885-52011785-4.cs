    <Project Sdk="Microsoft.NET.Sdk">
      <PropertyGroup>
        <TargetFramework>netstandard2.0</TargetFramework>
      </PropertyGroup>
      <Target Name="GenerateCode" BeforeTargets="CoreCompile">
    
        <Exec Command="mkdir Generated" Condition="!Exists('Generated')" />
        <Exec Command="echo class GeneratedClass { public static int MESSAGE = 1; } > Generated/GeneratedClass.cs" />
    
        <ItemGroup>
          <Compile Include="Generated/*$(DefaultLanguageSourceExtension)" Exclude="@(Compile)" />
        </ItemGroup>
    
      </Target>
    </Project>
