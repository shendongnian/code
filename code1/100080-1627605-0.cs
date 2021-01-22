    using System;
    using System.Reflection;
    internal class TypeNameWrapper : TypeDelegator
    {
       private string ReplacementName { get; set; }
       public TypeNameWrapper(Type innerType, string replacementName)
          : base(innerType)
       {
          this.ReplacementName = replacementName;
       }
       public override string Name
       {
          get { return this.ReplacementName; }
       }
    }
