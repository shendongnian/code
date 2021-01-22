    catch (FaultException soapEx)
    {
        MessageFault mf = soapEx.CreateMessageFault();
        if (mf.HasDetail)
        {
            XmlDictionaryReader reader = mf.GetReaderAtDetailContents();
            Guid g = reader.ReadContentAsGuid();
        }
    }
