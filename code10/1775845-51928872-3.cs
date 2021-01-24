    <Project Sdk="Microsoft.NET.Sdk">
        <PropertyGroup>
            <TargetFramework>netstandard2.0</TargetFramework>
            <RestoreProjectStyle>PackageReference</RestoreProjectStyle>
        </PropertyGroup>
        <!-- This is just for some projects referencing this project directly instead of the Nuget package -->
        <ItemGroup>
            <Content Include="NLog\NLog.config">
                <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
            </Content>
        </ItemGroup>
    </Project>
