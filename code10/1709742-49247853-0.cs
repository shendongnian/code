      <ItemGroup>
        <Compile Include="Form1.cs">
          <SubType>Form</SubType>
        </Compile>
        <Compile Include="Form1.Designer.cs">
          <DependentUpon>Form1.cs</DependentUpon>
        </Compile>
        <Compile Include="Form1Part2.cs">
          <DependentUpon>Form1.cs</DependentUpon>
        </Compile>
        <Compile Include="Program.cs" />
        <Compile Include="Properties\AssemblyInfo.cs" />
        <EmbeddedResource Include="Properties\Resources.resx">
          <Generator>ResXFileCodeGenerator</Generator>
          <LastGenOutput>Resources.Designer.cs</LastGenOutput>
          <SubType>Designer</SubType>
        </EmbeddedResource>
        <Compile Include="Properties\Resources.Designer.cs">
          <AutoGen>True</AutoGen>
          <DependentUpon>Resources.resx</DependentUpon>
        </Compile>
        <None Include="Properties\Settings.settings">
          <Generator>SettingsSingleFileGenerator</Generator>
          <LastGenOutput>Settings.Designer.cs</LastGenOutput>
        </None>
        <Compile Include="Properties\Settings.Designer.cs">
          <AutoGen>True</AutoGen>
          <DependentUpon>Settings.settings</DependentUpon>
          <DesignTimeSharedInput>True</DesignTimeSharedInput>
        </Compile>
      </ItemGroup>
