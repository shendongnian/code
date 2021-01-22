    <ItemGroup>    
      <Assemblies Include = "S:\SVN\SomeDirectory\src\">
        <excludeAssembly>exludeAssemblySet</excludeAssembly>
      </Assemblies>
    </ItemGroup>
    <ItemGroup>
      <exludeAssemblySet Include="AssemblyName_1"/>
      <exludeAssemblySet Include="AssemblyName_2"/>
      <exludeAssemblySet Include="AssemblyName_3"/>
      <exludeAssemblySet Include="AssemblyName_4"/>
    </ItemGroup>
    // Approximative syntax, I don't know what you want to do
    var itemData = itemTask.GetMetadata("excludeAssembly");
    BuildItemGroup excludeAssemblies = project.GetEvaluatedItemsByName(itemData);
