    using System;
    namespace BitfieldTest
    {
      [global::System.AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
      sealed class BitfieldLengthAttribute : Attribute
      {
        uint length;
        public BitfieldLengthAttribute(uint length)
        {
            this.length = length;
        }
        public uint Length { get { return length; } }
      }
      static class PrimitiveConversion
      {
        public static long ToLong<T>(T t) where T : struct
        {
            long r = 0;
            int offset = 0;
            // For every field suitably attributed with a BitfieldLength
            foreach (System.Reflection.FieldInfo f in t.GetType().GetFields())
            {
                object[] attrs = f.GetCustomAttributes(typeof(BitfieldLengthAttribute), false);
                if (attrs.Length == 1)
                {
                    uint fieldLength  = ((BitfieldLengthAttribute)attrs[0]).Length;
                    // Calculate a bitmask of the desired length
                    long mask = 0;
                    for (int i = 0; i < fieldLength; i++)
                        mask |= 1 << i;
                    r |= ((UInt32)f.GetValue(t) & mask) << offset;
                    offset += (int)fieldLength;
                }
            }
            return r;
        }
      }
      struct PESHeader
      {
        [BitfieldLength(2)]
        public uint reserved;
        [BitfieldLength(2)]
        public uint scrambling_control;
        [BitfieldLength(1)]
        public uint priority;
        [BitfieldLength(1)]
        public uint data_alignment_indicator;
        [BitfieldLength(1)]
        public uint copyright;
        [BitfieldLength(1)]
        public uint original_or_copy;
      };
      public class MainClass
      {
        public static void Main(string[] args)
        {
            PESHeader p = new PESHeader();
            p.reserved = 3;
            p.scrambling_control = 2;
            p.data_alignment_indicator = 1;
            long l = PrimitiveConversion.ToLong(p);
            for (int i = 63; i >= 0; i--)
            {
               Console.Write( ((l & (1l << i)) > 0) ? "1" : "0");
            }
            Console.WriteLine();
            return;
        }
      }
    }
