            private static XDocument GenerateSomeXml()
        {
            return XDocument.Parse(@"<MyObject>
                                <Properties>
                                   <Name>My object 1</Name>
                                   <Position>0; 0; 0</Position>
                                </Properties>
                             </MyObject>");
        }
