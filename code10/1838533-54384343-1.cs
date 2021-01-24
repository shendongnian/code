csharp
public abstract Soldier
{
  public abstract char Symbol { get; }
  public virtual string Name { get; } = "Soldier";
  public string Weapon { get; protected set; } = "Gun";
}
public Rifleman : Soldier
{
  public override char Symbol => 'r';
  public override string Name => nameof(Rifleman);
}
public Sniper : Soldier
{
  public Solder()
  {
    Weapon = "Rifle";
  }
  public override char Symbol => 's';
}
Fields should almost always be private, and are often unnecessary in modern versions of C# (what you see above are language features that should work with any .NET Framework or Core version).
