    <Project InitialTargets="CleanGen" Sdk="Microsoft.NET.Sdk">
      <PropertyGroup>
        <TargetFramework>netstandard2.0</TargetFramework>
      </PropertyGroup>
      <Target Name="CleanGen">
        <Exec Command="echo 'Cleaning files...'" />
        <Exec Command="rm $(ProjectDir)Generated/*$(DefaultLanguageSourceExtension)" IgnoreExitCode="true" />
      </Target>
      <Target Name="GenerateCode" BeforeTargets="CoreCompile">
        <Exec Command="echo 'Generating files... $(NuGetPackageRoot)'" />
        <Exec Command="echo 'class GeneratedClass { public static int MESSAGE = 1; }' >> Generated/GeneratedClass.cs" />
        <ItemGroup>
          <Compile Include="Generated/*$(DefaultLanguageSourceExtension)" />
        </ItemGroup>
      </Target>
    </Project>
