    private static bool? _isEvidenceObsolete = null;
    public static Assembly AssemblyLoader(string assembly, Evidence evidence)
    {
        Assembly asm;
        if (!_isEvidenceObsolete.HasValue)
        {
            MethodInfo load =
               typeof(Assembly).GetMethod("Load",
                                           new Type[] { typeof(string), typeof(Evidence) });
            _isEvidenceObsolete = Attribute.IsDefined(load, typeof(ObsoleteAttribute));
        }
        if (_isEvidenceObsolete.Value)
        {
            asm = Assembly.Load(assembly);
        }
        else
        {
            asm = Assembly.Load(assembly, evidence);
        }
        return asm;
    }
