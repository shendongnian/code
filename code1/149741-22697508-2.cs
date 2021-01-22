    bool isAvailable = RdRandom.GeneratorAvailable();  // Check to see if this is a compatible CPU
    string key       = RdRandom.GenerateKey(10);       // Generate 10 random characters
    string apiKey    = RdRandom.GenerateAPIKey();      // Generate 64 random characters, useful for API keys
    byte[] b         = RdRandom.GenerateBytes(10);     // Generate an array of 10 random bytes
    uint i           = RdRandom.GenerateUnsignedInt()  // Generate a random unsigned int
