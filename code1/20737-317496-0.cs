    public IEnumerable<AClass> SomeMethod() {
        // ...
        foreach (XElement header in headersXml.Root.Elements()){
            yield return (ParseHeader(header));                
        }
    }
