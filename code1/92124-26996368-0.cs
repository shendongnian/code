    <Target Name="AfterBuild">
        <GetAssemblyIdentity AssemblyFiles="$(OutDir)$(TargetFileName)">
          <Output TaskParameter="Assemblies" ItemName="TargetAssemblyIdentity" />
        </GetAssemblyIdentity>
        <PropertyGroup>
          <PublishVersion>%(TargetAssemblyIdentity.Version)</PublishVersion>
        </PropertyGroup>
    </Target>
