    <Target Name="ChangeAliasesOfStrongNameAssemblies" BeforeTargets="FindReferenceAssembliesForReferences;ResolveReferences">
        <ItemGroup>
          <ReferencePath Condition="'%(FileName)' == 'Syncfusion.Compression.Portable'">
            <Aliases>compression</Aliases>
          </ReferencePath>
        </ItemGroup>
      </Target>
