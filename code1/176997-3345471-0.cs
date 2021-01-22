    public object DeepCopy(object source)
    {
       // Copy with Binary Serialization if the object supports it
       // If not try copying with XML Serialization
       // If not try copying with Data contract Serailizer, etc
    }
