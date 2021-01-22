    static bool HasComoundDocumentSignature(string filename)
    {
        using (BinaryReader br = new BinaryReader(File.Open(filename, FileMode.Open)))
        {
            UInt16 magicNumber = br.ReadUInt16();      
            return magicNumber == 0xcfd0;
        }
    }
    static bool HasZipSignature(string filename)
    {
        using (BinaryReader br = new BinaryReader(File.Open(filename, FileMode.Open)))
        {
            UInt16 magicNumber = br.ReadUInt16();  
            return magicNumber == 0x4b50;
        }
    }
    static bool HasWordSignature(string filename)
    {
        return HasCompoundDocumentSignature(filename) 
            || HasZipSignature(filename); 
    }
