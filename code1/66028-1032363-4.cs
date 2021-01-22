        XDocument doc = new XDocument(
            new XDeclaration("1.0", null, null),
            new XElement(_pluralCamelNotation, 
                Enumerable.Range(1,3).Select(
                    i => new XElement(_singularCamelNotation,
                        _allDataTypes.Select(
                            dataType => new XElement(
                                dataType.ToString(),
                                dataType.GetDummyData())
                        )
                ))));
        string t = doc.ToString();
