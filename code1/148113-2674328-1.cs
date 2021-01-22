    private Stream SerializeMultipleObjects()
    { 
        // Initialize a storage medium to hold the serialized object
        Stream stream = new MemoryStream();
    
        // Serialize an object into the storage medium referenced by 'stream' object.
        BinaryFormatter formatter = new BinaryFormatter();
    
        // Serialize multiple objects into the stream
        formatter.Serialize( stream, obOrders );
        formatter.Serialize( stream, obProducts );
        formatter.Serialize( stream, obCustomers );
    
        // Return a stream with multiple objects
        return stream; 
    }
    
    private void DeSerializeMultipleObject(Stream stream)
    {
        // Construct a binary formatter
        BinaryFormatter formatter = new BinaryFormatter();
    
        // Deserialize the stream into object
        Orders     obOrders    = (Orders)formatter.Deserialize( stream );
        Products   obProducts  = (Products)formatter.Deserialize( stream );
        Customers  obCustomers = (Customer)formatter.Deserialize( stream );
    }
