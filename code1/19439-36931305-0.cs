    [Test]
    public void Foo()
    {
       ...
       XmlAssert.Equal(expected, actual, XmlAssertOptions.IgnoreDeclaration | XmlAssertOptions.IgnoreNamespaces);
    }
