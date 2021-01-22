    [StructLayout(LayoutKind.Explicit, Size=8)]
    public struct SomeStruct
    { 
       [FieldOffset(0)] private byte b0;
       [FieldOffset(1)] private byte b1;
       [FieldOffset(2)] private byte b2;
       [FieldOffset(3)] private byte b3;
       [FieldOffset(4)] private byte b4;
       [FieldOffset(5)] private byte b5;
       [FieldOffset(6)] private byte b6;
       [FieldOffset(7)] private byte b7;
       // not thread safe - alter accordingly if that is a requirement
       private readonly static byte[] scratch = new byte[4];       
       public byte SomeByte 
       { 
           get { return b0; }
           set { b0 = value; }
       }
       
       public int SomeInt
       {
           get 
           { 
               // get the right endianess for your system this is just an example!
               scratch[0] = b1;
               scratch[1] = b2;
               scratch[2] = b3;
               scratch[3] = b4;
               return BitConverter.ToInt32(scratch, 0);
           }
       }
       
       public short SomeShort
       {
            get 
            { 
                // get the right endianess for your system this is just an example!
                scratch[0] = b5;
                scratch[1] = b6;
                return BitConverter.ToInt16(scratch, 0);
            }
        }
        public byte SomeByte2 
        { 
            get { return b7; }
            set { b7 = value; }
        }
    }
