     public static class BitArrayExtender {
        
        public static byte[] ToByteArray( this BitArray bits ) {
        
            const int BYTE = 8;
            int length = ( bits.Count / BYTE ) + ( (bits.Count % BYTE == 0) ? 0 : 1 );
            var bytes  = new byte[ length ];
        
            for ( int i = 0; i < bits.Length; i++ ) {
              
               int bitIndex  = i % BYTE;
               int byteIndex = i / BYTE;
        
               int mask = (bits[ i ] ? 1 : 0) << bitIndex;
               bytes[ byteIndex ] |= (byte)mask;
        
            }//for
        
            return bytes;
        
        }//ToByteArray
    
     }//class
