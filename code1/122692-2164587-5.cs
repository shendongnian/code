    var serializer = new XmlSerializer(typeof(Root));
    string xml = @"
      <Root xmlns='http://example.com/Root'>
        <Something>
          <SomethingElse>Yep!</SomethingElse>
        </Something>
      </Root>"; // remember to use the XML namespace!
    Debug.Assert(serializer.CanDeserialize(new XmlTextReader(new StringReader(xml))));
