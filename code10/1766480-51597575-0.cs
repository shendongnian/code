      <Choose>
        <When Condition="'$(Configuration)'=='Release'">
          <ItemGroup>
            <Reference Include="Your.AssemblyName">
              <HintPath>..\Your.AssemblyName\bin\x86\release\Your.AssemblyName.dll</HintPath>
            </Reference>
          </ItemGroup>
        </When>
        <Otherwise>
          <ItemGroup>
            <Reference Include="Your.AssemblyName">
              <HintPath>..\Your.AssemblyName\bin\x86\debug\Your.AssemblyName.dll</HintPath>
            </Reference>
          </ItemGroup>
        </Otherwise>
      </Choose>
