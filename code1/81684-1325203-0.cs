    public void WriteBytes(BinaryWriter writer)
    {
        writer.Write((byte)0); // reserved
        writer.Write((byte)0); // request = 0
        
        writer.Write(Task_number);
        writer.Write(Transaction_id);
        writer.Write(error_code);
        
        writer.Write(Data_length);
        
        subBuffer.WriteBytes(writer);
    }
