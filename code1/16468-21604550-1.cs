    // All elements of this list are guaranteed to be immutable
    List<Immutable<SampleElement>> elements = 
        new List<Immutable<SampleElement>>();
    for (int i = 1; i < 10; i++) 
    {
        SampleElement newElement = new SampleElement();
        newElement.Id = Guid.NewGuid();
        newElement.Name = "Sample" + i.ToString();
        // The compiler will automatically convert to Immutable<SampleElement> for you
        // because of the implicit conversion operator
        elements.Add(newElement);
    }
    foreach (SampleElement element in elements)
        Console.Out.WriteLine(element.Name);
    elements[3].Value.Id = Guid.NewGuid();      // This will throw an ImmutableElementException
