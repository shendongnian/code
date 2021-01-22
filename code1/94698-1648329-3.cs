    [Test]
    public void Execute_WithoutSystemReflectionPrefixOrAttributeSuffix_ReturnsExpectedResult()
    {
        string version = getAssemblyFileVersion();
        Assert.IsNotNull(version, "Expected AssemblyFileVersionAttribute to contain value");
        task.AssemblyFile = assemblyFile;
        task.Attribute = "AssemblyFileVersion";
        task.Value = "Bogus";
        result = task.Execute();
        Assert.IsTrue(result, "Expected execute to pass on valid assembly and attribute name");
        Assert.AreEqual(task.Value, version,
            "Expected task value to match assembly file version attribute value");
    }
