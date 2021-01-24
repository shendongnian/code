    public class DisplayAttributeWeaver : BaseModuleWeaver
    {
      public override void Execute()
      {
        var dataAnnotationAssembly = ModuleDefinition.AssemblyReferences.First (e => e.Name.Contains ("DataAnnotation"));
        var resolvedDataAnnotationAssembly = ModuleDefinition.AssemblyResolver.Resolve (dataAnnotationAssembly);
        var displayAttribute = resolvedDataAnnotationAssembly.Modules.First().GetType ("System.ComponentModel.DataAnnotations.DisplayAttribute");
        var displayAttributeConstructor = ModuleDefinition.ImportReference(displayAttribute.GetConstructors().First());
    
        foreach (var type in ModuleDefinition.Types)
        {
          var targetAttribute = type.CustomAttributes.FirstOrDefault (e => e.AttributeType.Name == "DisplayPatchAttribute");
          if (targetAttribute == null)
            continue;
          
          type.CustomAttributes.Remove (targetAttribute);
    
          var newAttr = new CustomAttribute (displayAttributeConstructor);
          type.CustomAttributes.Add (newAttr);
        }
      }
    
      public override IEnumerable<string> GetAssembliesForScanning()
      {
        yield return "mscorlib";
        yield return "System";
      }
    }
