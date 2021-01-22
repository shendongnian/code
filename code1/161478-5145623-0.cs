    using ImpromptuInterface;
  
    public interface ISimpeleClassProps
    {
        string Prop1 { get;  }
        long Prop2 { get; }
        Guid Prop3 { get; }
    }
-
    dynamic tOriginal= new ExpandoObject();
    tOriginal.Prop1 = "Test";
    tOriginal.Prop2 = 42L;
    tOriginal.Prop3 = Guid.NewGuid();
    
    ISimpeleClassProps tActsLike = Impromptu.ActLike<ISimpeleClassProps>(tOriginal);
