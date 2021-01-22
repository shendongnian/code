    namespace Swizzle
    {
        /// <summary>
        /// This implements the Vector4 class as described in the question, based on our totally generic
        /// Vector class.
        /// </summary>
        class Vector4 : Vector
        {
            public Vector4(int val0, int val1, int val2, int val3)
                : base(new Dictionary<char, int> { {'t', 0}, {'x', 1}, {'y', 2}, {'z', 3},
                                                   {'a', 0}, {'r', 1}, {'g', 2}, {'b', 3}},
                       new int[] { val0, val1, val2, val3 })
            { }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                dynamic v1, v2;
                // (t,x,y,z) or (alpha,r,g,b)
                v1 = new Vector4(1, 2, 0, 0);
                v2 = new Vector4(0, 0, 3, 4);
    
                // v1 (Green, Z) = v2 (Y, Blue)
                v1.gz = v2.yb;
    
                Console.WriteLine("v1: {0}, {1}, {2}, {3}", v1[0], v1[1], v1[2], v1[3]);
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);
            }
        }
        class Vector : DynamicObject
        {
            private int[] m_values;
            private Dictionary<char, int> m_positions;
    
            public Vector(Dictionary<char, int> positions, params int[] values)
            {
                this.m_positions = positions;
                this.m_values = values;
            }
    
            public int this[int index] {
                get { return this.m_values[index]; }
            }
    
            public int Length
            {
                get { return this.m_values.Length; }
            }
    
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                if (binder.Name == "Length") {
                    result = this.Length;
                    return true;
                }
    
                Dictionary<char, int> positions = new Dictionary<char, int>(binder.Name.Length);
                List<int> values = new List<int>(binder.Name.Length);
                int i = 0;
                foreach (char c in binder.Name)
                {
                    if (!this.m_positions.ContainsKey(c))
                        return base.TryGetMember(binder, out result);
    
                    values.Add(m_values[m_positions[c]]);
                    positions.Add(c, i);
    
                    i++;
                }
    
                result = new Vector(positions, values.ToArray());
                return true;
            }
    
            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                // sanity checking.
                foreach (char c in binder.Name)
                {
                    if (!this.m_positions.ContainsKey(c))
                        return false;
                }
    
                Vector vectorValue = value as Vector;
    
                if (vectorValue == null) 
                    throw new ArgumentException("You may only set properties of a Vector to another Vector.");
                if (vectorValue.Length != binder.Name.Length)
                    throw new ArgumentOutOfRangeException("The length of the Vector given does not match the length of the Vector to assign it to.");
    
                int i = 0;
                foreach (char c in binder.Name)
                {
                    m_values[m_positions[c]] = vectorValue[i];
                    i++;
                }
    
                return true;
            }
        }
    }
