    var binding = new CustomBinding();
    TextMessageEncodingBindingElement textBindingElement = new TextMessageEncodingBindingElement
    {
        MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None),
        WriteEncoding = System.Text.Encoding.UTF8,
        ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max
    };
    binding.Elements.Add(textBindingElement);
