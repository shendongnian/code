    class Foo
    {
    public:
      const unsigned int SCHEMA = 2;
      int i;
      double d;
      string s;
    
      void Serialize(bool bSaving, CBinaryFile file)
      {
        if (bSaving)
        {
          // Serialize everything out
          file << SCHEMA << i << d << s;
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
          if (nSchema > 1)
            file >> s;
        }
      }
    }
