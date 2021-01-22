        Object DeepClone(Object original)
        {
            // Construct a temporary memory stream
            MemoryStream stream = new MemoryStream();
            // Construct a serialization formatter that does all the hard work
            BinaryFormatter formatter = new BinaryFormatter();
            // This line is explained in the "Streaming Contexts" section
            formatter.Context = new StreamingContext(StreamingContextStates.Clone);
            // Serialize the object graph into the memory stream
            formatter.Serialize(stream, original);
            // Seek back to the start of the memory stream before deserializing
            stream.Position = 0;
            // Deserialize the graph into a new set of objects
            // and return the root of the graph (deep copy) to the caller
            return (formatter.Deserialize(stream));
        }
