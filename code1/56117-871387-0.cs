    class Foo
    {
    public:
      const unsigned int SCHEMA = 1;
      int i;
      double d;
    
      void Serialize(bool bSaving, CBinaryFile file)
      {
        if (bSaving)
        {
          // Serialize everything out
          file << SCHEMA << i << d;
        }
        else
        {
          // Read in the schema number first
          unsigned int nSchema;
          file >> nSchema;
    
          // Validate the schema number
          if (nSchema > SCHEMA)
          {
            // We're reading in data that was written with a newer version of the program
            // Since we don't know how to handle that let's error out
            throw exception;
          }
          
          // Read everything in
          file >> i >> d;
        }
      }
    }
