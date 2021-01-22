    public object BeforeSendRequest(ref Message request, IClientChannel channel)
    {
        International intlHeader = new International();
        intlHeader.Locale = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
    
        MessageHeader header = MessageHeader.CreateHeader(WSI18N.ElementNames.International, WSI18N.NamespaceURI, intlHeader);
        request.Headers.Add(header);
    
        return null;
    }
