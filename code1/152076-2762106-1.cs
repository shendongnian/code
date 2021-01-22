    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    .
    .
    .
    public void Test()
    {
        string xml = @"<root>
                      <product>product name</product>
                      <SomeHighLevelElement>
                        <anotherElment>
                          <lowestElement>foo</lowestElement>
                        </anotherElment>
                      </SomeHighLevelElement>
                      <SomeHighLevelElement>
                        <anotherElment>
                          <lowestElement>bar</lowestElement>
                        </anotherElment>
                      </SomeHighLevelElement>
                      <SomeHighLevelElement>
                        <anotherElment>
                          <lowestElement>baz</lowestElement>
                        </anotherElment>
                      </SomeHighLevelElement>
                    </root>";
        MyClass c = Deserialize<MyClass>(xml);
    }
    
    public T Deserialize<T>(string xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        return (T)serializer.Deserialize(new StringReader(xml));
    }
