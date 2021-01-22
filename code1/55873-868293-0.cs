    /// <summary>
    /// Serializes the entity to XML.
    /// </summary>
    /// <returns>String containing serialized entity.</returns>
    public string Serialize()
    {
        return DataContractCloner.Serialize<Organization>(this);
    }
    /// <summary>
    /// Deserializes the entity from XML.
    /// </summary>
    /// <param name="xml">Serialized entity.</param>
    /// <returns>Deserialized entity.</returns>
    public static Organization Deserialize(string xml)
    {
        return DataContractCloner.Deserialize<Organization>(xml);
    }
