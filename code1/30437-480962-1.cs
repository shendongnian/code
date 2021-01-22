using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace TestShortUnion {
    [StructLayout(LayoutKind.Explicit)]
    public struct shortbyte {
        public static implicit operator shortbyte(int input) {
            if (input > short.MaxValue)
                throw new ArgumentOutOfRangeException("input", "shortbyte only accepts values in the short-range");
            return new shortbyte((short)input);
        }
        public shortbyte(byte input) {
            shortval = 0;
            byteval = input;
        }
        public shortbyte(short input) {
            byteval = 0;
            shortval = input;
        }
        [FieldOffset(0)]
        public byte byteval;
        [FieldOffset(0)]
        public short shortval;
    }
    class Program {
        static void Main(string[] args) {
            shortbyte[] testarray = new shortbyte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1111 };
            foreach (shortbyte singleval in testarray) {
                Console.WriteLine("Byte {0}: Short {1}", singleval.byteval, singleval.shortval);
            }
            System.Console.ReadLine();
        }
    }
}
