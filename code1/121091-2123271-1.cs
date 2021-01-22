     [DataContract]
    public class FilePart
    {
        [DataMember] public int Part;
        [DataMember] public byte[] Data;
        [DataMember] public int BlockSize;
    }
