    if (signature.Attributes.GetNamedItem("id") is XmlAttribute oldId)
    {
        signature.Attributes.Remove(oldId);
        if (signature.OwnerDocument != null)
        {
            var newId = signature.OwnerDocument.CreateAttribute("Id");
            newId.Value = oldId.Value;
            signature.Attributes.Append(newId);
        }
    }
