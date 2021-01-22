    // Check to see if this is a compatible CPU
    bool isAvailable = RdRandom.GeneratorAvailable();
    // Generate 10 random characters
    string key       = RdRandom.GenerateKey(10);
     // Generate 64 random characters, useful for API keys 
    string apiKey    = RdRandom.GenerateAPIKey();
    // Generate an array of 10 random bytes
    byte[] b         = RdRandom.GenerateBytes(10);
    // Generate a random unsigned int
    uint i           = RdRandom.GenerateUnsignedInt();
