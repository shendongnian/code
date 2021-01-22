    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace StructTest
    {
    
        [StructLayout(LayoutKind.Explicit)]
        unsafe struct OuterType
        {
            private const int BUFFER_SIZE = 100;
    
            [FieldOffset(0)]
            private int transactionType;
    
            [FieldOffset(0)]
            private fixed byte writeBuffer[BUFFER_SIZE];
    
            public int TransactionType
            {
                get { return transactionType; }
                set { transactionType = value; }
            }
    
            public char[] WriteBuffer
            {
                set
                {
                    char[] newBuffer = value;
    
                    fixed (byte* b = writeBuffer)
                    {
                        byte* bptr = b;
                        for (int i = 0; i < newBuffer.Length; i++)
                        {
                             *bptr++ = (byte) newBuffer[i];
                        }
                    }
                }
    
                get
                {
                    char[] newBuffer = new char[BUFFER_SIZE];
    
                    fixed (byte* b = writeBuffer)
                    {
                        byte* bptr = b;
                        for (int i = 0; i < newBuffer.Length; i++)
                        {
                            newBuffer[i] = (char) *bptr++;
                        }
                    }
    
                    return newBuffer;
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                OuterType t = new OuterType();
                System.Console.WriteLine(t);
            }
        }
    }
