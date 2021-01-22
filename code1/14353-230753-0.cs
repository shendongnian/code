    lock (m_Hash)
    {
        // Across all threads, I can be in one and only one of these blocks
        // Do something with the dictionary
    }
    lock (m_Hash)
    {
        // Across all threads, I can be in one and only one of these blocks
        // Do something with the dictionary
    }
