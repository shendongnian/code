          public void Main()
          {
            AssemblyDefinition  assemblyDef = AssemblyDefinition.ReadAssembly(dllname);
  
            //Populate Tree
            foreach (ModuleDefinition tempModuleDef in assemblyDef.Modules)
            {
                foreach (TypeDefinition tempTypeDef in tempModuleDef.Types)
                {
                    BuildTree(tempModuleDef ,tempTypeDef, null);
                }
            }
          }
