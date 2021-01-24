    <Target Name="SetNuspecProperties" BeforeTargets="GenerateNuspec">
      <PropertyGroup>
        <NuspecProperties>$(NuspecProperties);id=$(AssemblyName)</NuspecProperties>
        <NuspecProperties>$(NuspecProperties);config=$(Configuration)</NuspecProperties>
        <NuspecProperties>$(NuspecProperties);version=$(PackageVersion)</NuspecProperties>
        <NuspecProperties>$(NuspecProperties);description=$(Description)</NuspecProperties>
        <NuspecProperties>$(NuspecProperties);authors=$(Authors)</NuspecProperties>
      </PropertyGroup>
    </Target>
