csharp
modelBuilder.Entity<Model>()
    .Property(x => x.Prop2)
    .HasConversion(
        p => p == null ? null : p.ToLower(),
        dbValue => dbValue);
Or, encapsulate within the class itself, using property with backing field:
csharp
private string _prop2;
public string Prop2
{ 
    get => _prop2;
    set => value?.ToLower();
}
