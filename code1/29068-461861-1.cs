        string testValue =
            (string) XElement.Load("file.xml")
                .Element("entities")
                .Elements("entity")
                .FirstOrDefault(entity => entity.Attribute("ID")
                    .Value == "1") ?? string.Empty;
        file.xml
        --------
        <?xml version="1.0" encoding="utf-8" ?>
        <application>
          <parameters>
            <param></param>
            <param></param>
          </parameters>
          <generation />
          <entities>
            <entity ID="1">
              <PropTest>Test 1</PropTest>
            </entity>
            <entity ID="2">
              <PropTest>Test 2</PropTest>
            </entity>
          </entities>
        </application>
