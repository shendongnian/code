    theObject.Should().BeXmlSerializable();
    theObject.Should().BeBinarySerializable();
    theObject.Should().BeDataContractSerializable();
    
    theObject.Should().BeBinarySerializable<MyClass>(
    	options => options.Excluding(s => s.SomeNonSerializableProperty));
