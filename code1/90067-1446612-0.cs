    public class MyClass {
    
       public int Id { get; set; }
       public string Name { get; set; }
    
       public byte[] Serialize() {
          using (MemoryStream m = new MemoryStream()) {
             using (BinaryWriter writer = new BinaryWriter(m)) {
                writer.Write(Id);
                writer.Write(Name);
             }
             return m.ToArray();
          }
       }
    
       public static MyClass Desserialize(byte[] data) {
          MyClass result = new MyClass();
          using (MemoryStream m = new MemoryStream(data)) {
             using (BinaryReader reader = new binaryReader(m)) {
                Id = reader.ReadInt32();
                Name = reader.ReadString();
             }
          }
          return result;
       }
    
    }
