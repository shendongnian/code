    /// <summary>Builds PXUCAMR/PXUCAMRV3 as a byte array.</summary>
    internal class PxucamrBuilder
    {
        internal byte[] Pxucamr;
    
        /// <summary>Get/set field xumrversaocomc01, offset 0, size 1 byte.</summary>
        internal string StructureVersion
        {
            get { return Encoding.ASCII.GetString(this.Pxucamr, 0, 1); }
            set { Encoding.ASCII.GetBytes(value, 0, 1, this.Pxucamr, 0); }
        }
    
        /// <summary>Get/set field xumrambientec01, offset 12, size 1 byte.</summary>
        internal string Context
        {
            get { return Encoding.ASCII.GetString(this.Pxucamr, 12, 1); }
            set { Encoding.ASCII.GetBytes(value, 0, 1, this.Pxucamr, 12); }
        }
    
        /// <summary>Get/set field xumrcodfalhac05, offset 5, size 5 byte.</summary>
        internal string ErrorCode
        {
            get { return Encoding.ASCII.GetString(this.Pxucamr, 5, 5); }
            set { Encoding.ASCII.GetBytes(value, 0, 5, this.Pxucamr, 5); }
        }
    
        /// <summary>Get/set field xumridservidorc30, offset 130, size 30 bytes.</summary>
        internal string ServerId
        {
            get { return Encoding.ASCII.GetString(this.Pxucamr, 130, 30); }
            set { Encoding.ASCII.GetBytes(value, 0, value.Length, this.Pxucamr, 130); }
        }
        
        /// <summary>Get/set field xumrtamdadosb31, offset 24, size 4 byte.</summary>
        internal int DataSize
        {
            get
            {
                byte[] bytes = new byte[4];
                Array.Copy(this.Pxucamr, 24, bytes, 0, 4);
                return this.ByteArrayToInt32(bytes);
            }
            set
            {
                byte[] bytes = this.Int32ToByteArray(value);
                Array.Copy(bytes, 0, this.Pxucamr, 24, 4);
            }
        }
        
        /* ... same pattern to remaining fields ... */   
    }
