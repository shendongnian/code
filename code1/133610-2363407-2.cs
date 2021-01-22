      <ItemGroup>
        <Compile Include="Debug\Resource1.Designer.cs" Condition=" '$(Configuration)' == 'Debug' ">
          <AutoGen>True</AutoGen>
          <DesignTime>True</DesignTime>
          <DependentUpon>Resource1.resx</DependentUpon>
        </Compile>
        <Compile Include="Program.cs" />
        <Compile Include="Properties\AssemblyInfo.cs" />
        <Compile Include="Queue.cs" />
        <Compile Include="Release\Resource1.Designer.cs" Condition=" '$(Configuration)' == 'Release' ">
          <AutoGen>True</AutoGen>
          <DesignTime>True</DesignTime>
          <DependentUpon>Resource1.resx</DependentUpon>
        </Compile>
        <Compile Include="Stack.cs" />
      </ItemGroup>
      <ItemGroup>
        <Content Include="XMLFile1.xml" />
      </ItemGroup>
      <ItemGroup>
        <EmbeddedResource Include="Debug\Resource1.resx" Condition=" '$(Configuration)' == 'Debug' ">
          <Generator>ResXFileCodeGenerator</Generator>
          <LastGenOutput>Resource1.Designer.cs</LastGenOutput>
          <CustomToolNamespace>Resources</CustomToolNamespace>
        </EmbeddedResource>
        <EmbeddedResource Include="Release\Resource1.resx" Condition=" '$(Configuration)' == 'Release' ">
          <Generator>ResXFileCodeGenerator</Generator>
          <LastGenOutput>Resource1.Designer.cs</LastGenOutput>
          <CustomToolNamespace>Resources</CustomToolNamespace>
        </EmbeddedResource>
      </ItemGroup>
