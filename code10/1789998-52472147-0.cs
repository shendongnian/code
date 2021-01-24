    <Project Sdk="Microsoft.NET.Sdk">
      <PropertyGroup>
        <TargetFramework>netstandard2.0</TargetFramework>
        <RootNamespace>Cds.IoC</RootNamespace>
        <GeneratePackageOnBuild>true</GeneratePackageOnBuild>
        <Authors>...</Authors>
        <Company>...</Company>
        <Product>...</Product>
        <Description>...</Description>
        <Copyright>© 2018</Copyright>
        <PackageTags>...</PackageTags>
        <PackageReleaseNotes>...</PackageReleaseNotes>
        <AssemblyVersion>0.0.0.1</AssemblyVersion>
        <FileVersion>0.0.0.1</FileVersion>
        <Version>1.0.1-alpha</Version>
      </PropertyGroup>
      <ItemGroup>
        <None Update="some.tt">
          <Generator>TextTemplatingFileGenerator</Generator>
          <LastGenOutput>some.txt</LastGenOutput>    
        </None>
        <None Update="some.txt">
          <DesignTime>True</DesignTime>
          <AutoGen>True</AutoGen>
          <DependentUpon>some.tt</DependentUpon>
          <Pack>true</Pack>
        </None>
      </ItemGroup>
    </Project>
