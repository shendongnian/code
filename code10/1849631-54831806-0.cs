csharp
public override Task DoMyThing()
{
    // ..
    return Task.CompletedTask; // or Task.FromResult(0); in pre .NET Framework 4.6
}
