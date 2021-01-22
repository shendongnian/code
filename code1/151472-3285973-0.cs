    /// <summary>
    /// Serialize the state to XML
    /// </summary>
    /// <param name="writer">The writer to write the state</param>
    public void WriteXml(XmlWriter writer)
    {
        writer.WriteElementString("TERMINATION_STATUS", Status);
        writer.WriteElementString("TRANS_SEQ_NUM", Sequence.ToString());
        writer.WriteElementString("INTRN_SEQ_NUM", Id.ToString());
        writer.WriteElementString("CMRCL_FLAG", IsCommercialCard.ToString());
        writer.WriteElementString("AUTH_CODE", Authorization);
        writer.WriteElementString("CMRCL_TYPE", CommericalFlag.ToString());
        writer.WriteElementString("RESULT_CODE", ResultCode.ToString());
        writer.WriteElementString("TROUTD", RoutingId.ToString());
        writer.WriteElementString("RESPONSE_TEXT", Message);
        writer.WriteElementString("REFERENCE", ProcessorReferenceCode);
        writer.WriteElementString("PAYMENT_MEDIA", PaymentMedia);
        writer.WriteElementString("RESULT", Result.ToString().ToUpper());
        if (Error != null)
        {
            writer.WriteStartElement("ERROR");
            writer.WriteElementString("ERROR_CODE", Error.Code);
            writer.WriteElementString("ERROR_DESCRIPTION", Error.Description);
            writer.WriteEndElement();
        }
    }
