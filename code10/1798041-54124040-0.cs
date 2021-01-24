    [Fact]
    public void SerializeObjectsToInitializerCode()
    {
        // Create C# object
        var testObjects = new List<TestObject>
        {
            new TestObject {IDMacroTab = 1, IDTab = 1, IDSIot = 2},
            new TestObject {IDMacroTab = 1, IDTab = 2, IDSIot = 1},
            new TestObject {IDMacroTab = 1, IDTab = 2, IDSIot = 2}
        };
    
        // Pass it to ObjectDumper, choose DumpStyle.CSharp to generate C# initializer code
        var dump = ObjectDumper.Dump(testObjects, DumpStyle.CSharp);
    
        // Print to console, write to file, etc...
        _testOutputHelper.WriteLine(dump);
    }
