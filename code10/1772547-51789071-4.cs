    namespace System
    {
        public class BitCheck8 : global::System.IEquatable<byte>, global::System.IEquatable<global::System.BitCheck8>, global::System.Collections.Generic.IEnumerable<bool>, global::System.Collections.Generic.IDictionary<int, bool>
        {
            public const byte Empty = 0x0;
            protected byte Control;
            protected static global::System.ArgumentOutOfRangeException OutOfRange() { return new global::System.ArgumentOutOfRangeException("pos", "Argument [Pos] not between 0-7"); }
            public static bool IsBitSet(byte b, int pos) { if (pos < 0 || pos > 7) { throw global::System.BitCheck8.OutOfRange(); } else { return (b & (1 << pos)) != 0; } }
            public static byte SetBit(byte b, int pos) { if (pos < 0 || pos > 7) { throw global::System.BitCheck8.OutOfRange(); } else { return (byte)(b | (1 << pos)); } }
            public static byte UnsetBit(byte b, int pos) { if (pos < 0 || pos > 7) { throw global::System.BitCheck8.OutOfRange(); } else { return (byte)(b & ~(1 << pos)); } }
            public static byte ToggleBit(byte b, int pos) { if (pos < 0 || pos > 7) { throw global::System.BitCheck8.OutOfRange(); } else { return (byte)(b ^ (1 << pos)); } }
            public static string ToBinaryString(byte b) { return global::System.Convert.ToString(b, 2).PadLeft(8, '0'); }
            public virtual bool IsReadOnly { get { return false; } }
            public byte Base { get { return this.Control; } set { if (!this.IsReadOnly) { this.Control = value; } } }
            public bool IsBitSet(int pos) { return global::System.BitCheck8.IsBitSet(this.Control, pos); }
            public void SetBit(int pos) { if (!this.IsReadOnly) { this.Control = global::System.BitCheck8.SetBit(this.Control, pos); } }
            public void UnsetBit(int pos) { if (!this.IsReadOnly) { this.Control = global::System.BitCheck8.UnsetBit(this.Control, pos); } }
            public void ToggleBit(int pos) { if (!this.IsReadOnly) { this.Control = global::System.BitCheck8.ToggleBit(this.Control, pos); } }
            public void Clear() { if (!this.IsReadOnly) { this.Control = global::System.BitCheck8.Empty; } }
            public override string ToString() { return global::System.BitCheck8.ToBinaryString(this.Control); }
            public bool this[int pos] { get { return this.IsBitSet(pos); } set { if (value) { this.SetBit(pos); } else { this.UnsetBit(pos); } } }
            public bool Check0 { get { return this[0]; } set { this[0] = value; } }
            public bool Check1 { get { return this[1]; } set { this[1] = value; } }
            public bool Check2 { get { return this[2]; } set { this[2] = value; } }
            public bool Check3 { get { return this[3]; } set { this[3] = value; } }
            public bool Check4 { get { return this[4]; } set { this[4] = value; } }
            public bool Check5 { get { return this[5]; } set { this[5] = value; } }
            public bool Check6 { get { return this[6]; } set { this[6] = value; } }
            public bool Check7 { get { return this[7]; } set { this[7] = value; } }
            public global::System.Collections.Generic.IEnumerator<bool> GetEnumerator() { for (int pos = 0; pos < 8; pos++) { yield return this.IsBitSet(pos); } }
            global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
            bool global::System.IEquatable<byte>.Equals(byte b) { return this.Control == b; }
            public override bool Equals(object obj) { return base.Equals(obj); }
            public bool Equals(global::System.BitCheck8 obj) { return base.Equals(obj); }
            public override int GetHashCode() { return base.GetHashCode(); }
            void global::System.Collections.Generic.ICollection<global::System.Collections.Generic.KeyValuePair<int, bool>>.Add(global::System.Collections.Generic.KeyValuePair<int, bool> item) { this[item.Key] = item.Value; }
            bool global::System.Collections.Generic.ICollection<global::System.Collections.Generic.KeyValuePair<int, bool>>.Contains(global::System.Collections.Generic.KeyValuePair<int, bool> item) { return this[item.Key]; }
            int global::System.Collections.Generic.ICollection<global::System.Collections.Generic.KeyValuePair<int, bool>>.Count { get { return 8; } }
            bool global::System.Collections.Generic.ICollection<global::System.Collections.Generic.KeyValuePair<int, bool>>.Remove(global::System.Collections.Generic.KeyValuePair<int, bool> item) { return false; }
            void global::System.Collections.Generic.IDictionary<int, bool>.Add(int Key, bool Value) { this[Key] = Value; }
            bool global::System.Collections.Generic.IDictionary<int, bool>.ContainsKey(int Key) { return (Key > -1 && Key < 8); }
            bool global::System.Collections.Generic.IDictionary<int, bool>.Remove(int Key) { return false; }
            global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<int, bool>> global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<int, bool>>.GetEnumerator() { for (int pos = 0; pos < 8; pos++) { yield return new global::System.Collections.Generic.KeyValuePair<int, bool>(pos, this[pos]); } }
            void global::System.Collections.Generic.ICollection<global::System.Collections.Generic.KeyValuePair<int, bool>>.CopyTo(global::System.Collections.Generic.KeyValuePair<int, bool>[] array, int index) { global::System.Array.Copy(new global::System.Collections.Generic.KeyValuePair<int, bool>[] { new global::System.Collections.Generic.KeyValuePair<int, bool>(0, this[0]), new global::System.Collections.Generic.KeyValuePair<int, bool>(1, this[1]), new global::System.Collections.Generic.KeyValuePair<int, bool>(2, this[2]), new global::System.Collections.Generic.KeyValuePair<int, bool>(3, this[3]), new global::System.Collections.Generic.KeyValuePair<int, bool>(4, this[4]), new global::System.Collections.Generic.KeyValuePair<int, bool>(5, this[5]), new global::System.Collections.Generic.KeyValuePair<int, bool>(6, this[6]), new global::System.Collections.Generic.KeyValuePair<int, bool>(7, this[7]) }, 0, array, index, 8); }
            global::System.Collections.Generic.ICollection<int> global::System.Collections.Generic.IDictionary<int, bool>.Keys { get { return (global::System.Collections.Generic.ICollection<int>)new int[] { 0, 1, 2, 3, 4, 5, 6, 7 }; } }
            global::System.Collections.Generic.ICollection<bool> global::System.Collections.Generic.IDictionary<int, bool>.Values { get { return (global::System.Collections.Generic.ICollection<bool>)new bool[] { this[0], this[1], this[2], this[3], this[4], this[5], this[6], this[7] }; } }
            public static bool operator ==(global::System.BitCheck8 obj1, global::System.BitCheck8 obj2) { return (obj1 != null && obj2 != null && obj1.Control == obj2.Control); }
            public static bool operator !=(global::System.BitCheck8 obj1, global::System.BitCheck8 obj2) { return (obj1 == null || obj2 == null || obj1.Control != obj2.Control); }
            public static bool operator ==(global::System.BitCheck8 obj1, byte obj2) { return (obj1 != null && obj1.Control == obj2); }
            public static bool operator !=(global::System.BitCheck8 obj1, byte obj2) { return (obj1 == null || obj1.Control != obj2); }
    
            bool global::System.Collections.Generic.IDictionary<int, bool>.TryGetValue(int Key, out bool Value)
            {
                Value = false;
                if (Key > -1 && Key < 8)
                {
                    Value = this.IsBitSet(Key);
                    return true;
                } else { return false; }
            }
    
            public static global::System.BitCheck8 operator +(global::System.BitCheck8 obj1, byte obj2)
            {
                if (obj1 == null) { return new global::System.BitCheck8(obj2); }
                else
                {
                    global::System.BitCheck8 a = new global::System.BitCheck8(obj1.Control);
                    for (int pos = 0; pos < 8; pos++) { if (global::System.BitCheck8.IsBitSet(obj2, pos)) { a[pos] = true; } }
                    return a;
                }
            }
    
            public static global::System.BitCheck8 operator -(global::System.BitCheck8 obj1, byte obj2)
            {
                if (obj1 == null) { return new global::System.BitCheck8(obj2); }
                else
                {
                    global::System.BitCheck8 a = new global::System.BitCheck8(obj1.Control);
                    for (int pos = 0; pos < 8; pos++) { if (!global::System.BitCheck8.IsBitSet(obj2, pos)) { a[pos] = false; } }
                    return a;
                }
            }
    
            public static global::System.BitCheck8 operator +(global::System.BitCheck8 obj1, global::System.BitCheck8 obj2) { return (obj2 == null ? obj1 : (obj1 + obj2.Control)); }
            public static global::System.BitCheck8 operator -(global::System.BitCheck8 obj1, global::System.BitCheck8 obj2) { return (obj2 == null ? obj1 : (obj1 - obj2.Control)); }
    
            public BitCheck8(bool Check0, bool Check1 = false, bool Check2 = false, bool Check3 = false, bool Check4 = false, bool Check5 = false, bool Check6 = false, bool Check7 = false)
            {
                this.Control = 0x0;
                this[0] = Check0;
                this[1] = Check1;
                this[2] = Check2;
                this[3] = Check3;
                this[4] = Check4;
                this[5] = Check5;
                this[6] = Check6;
                this[7] = Check7;
            }
    
            public BitCheck8(byte check) { this.Control = check; }
            public BitCheck8() { this.Clear(); }
        }
    }
