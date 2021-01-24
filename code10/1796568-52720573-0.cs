    private static readonly IEnumerable<string> BlockedAssemblies = new List<string>
    {   
        "System.Net.Http"
    };
    [Test]
    public void SpecificAssembliesAreNotReferenced()
    {
        var asm = Assembly.Load("Your.Assembly.File");
    
        var refs = asm.GetReferencedAssemblies();
        foreach(var a in refs)
        {
            Assert.False(BlockedAssemblies.Contains (a.Name), $"{a.Name} must not be referenced.");
        }
    }
