     System.Runtime.InteropServices.StructLayoutAttribute(  System.Runtime.InteropServices.LayoutKind.Sequential)]
     public struct cardData {
    
      /// byte[]
      public byte[] data01;
    
      /// byte[]
      public byte[] data02;
    }
    /// Return Type: cardData
    ///dataBuffer: cardData*
    public delegate cardData readCard(ref cardData dataBuffer);
