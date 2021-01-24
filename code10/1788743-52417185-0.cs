        <Project Sdk="Microsoft.NET.Sdk.Web">
    
           <!-- other stuff -->
    
           <Target Name="ChangeAliasesOfStrongNameAssemblies" BeforeTargets="FindReferenceAssembliesForReferences;ResolveReferences">
               <ItemGroup>
                   <ReferencePath Condition="'%(FileName)' == 'MySqlConnector'">
                       <Aliases>MySqlConnectorAlias</Aliases>
                   </ReferencePath>
               </ItemGroup>
          </Target>
    
          <!-- other stuff -->
    
        </Project>
