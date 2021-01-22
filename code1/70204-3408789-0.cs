    [Serializable]
    [AttributeUsage(AttributeTargets.Field)]
    public class MyAttribute : OnFieldAccessAspect
    {
        public override bool CompileTimeValidate(System.Reflection.FieldInfo field)
        {
            if (field.IsPublic || field.IsFamily)
            {
                throw new Exception("Attribute can only be applied to Public or Protected fields");
            }
    
            return true;
        }
    }
