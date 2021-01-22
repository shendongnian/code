ModuleDefinition module = ModuleDefinition.ReadModule(fullPathToTheAssembly);
foreach (var type in module.Types)
{
    foreach (var me in type.Methods)
    {
        if (!me.HasBody || me.IsGeneratedCode() || me.IsCompilerControlled)
            continue;
        var r = AvoidComplexMethodsRule.GetCyclomaticComplexity(me);
        Console.WriteLine("{0}: {1}", me.ToString(), r);
    }
}
