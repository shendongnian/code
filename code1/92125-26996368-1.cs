    <Target Name="AfterCompile">
        <GetAssemblyIdentity AssemblyFiles="$(IntermediateOutputPath)$(TargetFileName)">
          <Output TaskParameter="Assemblies" ItemName="TargetAssemblyIdentity" />
        </GetAssemblyIdentity>
        <PropertyGroup>
          <PublishVersion>%(TargetAssemblyIdentity.Version)</PublishVersion>
        </PropertyGroup>
    </Target>
