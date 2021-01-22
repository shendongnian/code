    class Foo {
      private int _someInteger;
      private string _someString;
      public virtual void Serialize(BinaryWriter writer) {
        writer.Write(2); // A simple versioning, start at 0, then increment.
        writer.Write(_someString);
        writer.Write(_someInteger);
      }
      public virtual void Deserialize(BinaryReader reader) {
        int version = reader.ReadInt32();
        switch (version) {
          case 2: // the string was only added in version 2 of the class serialization.
            _someString = reader.ReadString(); 
            goto case 1;
          case 1: // continue at case 1.
            _someInteger = reader.ReadInt32();
            break; // break here, because version 0 was very different.
          case 0: // in version 0 of the class there was actually a double, but it was always an integral number, so this basically is a conversion case.
            _someInteger = (int)reader.ReadDouble();
            break;
        }
      }
    }
