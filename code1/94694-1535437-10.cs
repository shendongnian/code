    namespace Swizzle
    {
        /// <summary>
        /// This implements the Vector4 class as described in the question, based on our totally generic
        /// Vector class.
        /// </summary>
        class Vector4 : Vector<int>
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
                dynamic v1, v2, v3;
                v1 = new Vector4(1, 2, 3, 4);
                v2 = v1.rgb;
                // Prints: v2.r: 2
                Console.WriteLine("v2.r: {0}", v2.r);
                // Prints: red: 2
                int red = v2.r;
                Console.WriteLine("red: {0}", red);
                // Prints: v2 has 3 elements.
                Console.WriteLine("v2 has {0} elements.", v2.Length);
                v3 = new Vector4(5, 6, 7, 8);
                v3.ar = v2.gb; // yes, the names are preserved! v3 = (3, 4, 7, 8)
                v2.r = 5;
                //v2.a = 5; // fails: v2 has no 'a' element, only 'r', 'g', and 'b'
                // Something fun that will also work
                Console.WriteLine("v3.gr: {0}", v3.gr);
                v3.rg = v3.gr; // switch green and red
                Console.WriteLine("v3.gr: {0}", v3.gr);
                Console.WriteLine("\r\nPress any key to continue.");
                Console.ReadKey(true);
            }
        }
        class Vector<T> : DynamicObject
        {
            private T[] m_values;
            private Dictionary<char, int> m_positions;
            public Vector(Dictionary<char, int> positions, params T[] values)
            {
                this.m_positions = positions;
                this.m_values = values;
            }
            public T this[int index] {
                get { return this.m_values[index]; }
            }
            public int Length
            {
                get { return this.m_values.Length; }
            }
            public override string ToString()
            {
                List<string> elements = new List<string>(this.Length);
                for (int i = 0; i < this.Length; i++)
                {
                    elements.Add(m_values[i].ToString());
                }
                return string.Join(", ", elements.ToArray());
            }
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                if (binder.Name == "Length") {
                    result = this.Length;
                    return true;
                }
                if (binder.Name.Length == 1 && this.m_positions.ContainsKey(binder.Name[0]))
                {
                    result = m_values[this.m_positions[binder.Name[0]]];
                    return true;
                }
                Dictionary<char, int> positions = new Dictionary<char, int>(binder.Name.Length);
                List<T> values = new List<T>(binder.Name.Length);
                int i = 0;
                foreach (char c in binder.Name)
                {
                    if (!this.m_positions.ContainsKey(c))
                        return base.TryGetMember(binder, out result);
                    values.Add(m_values[m_positions[c]]);
                    positions.Add(c, i);
                    i++;
                }
                result = new Vector<T>(positions, values.ToArray());
                return true;
            }
            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                // sanity checking.
                foreach (char c in binder.Name)
                {
                    if (!this.m_positions.ContainsKey(c))
                        return base.TrySetMember(binder, value);
                }
                Vector<T> vectorValue = value as Vector<T>;
                if (vectorValue == null && binder.Name.Length == 1 && value is T)
                {
                    m_values[m_positions[binder.Name[0]]] = (T)value;
                    return true;
                }
                else if (vectorValue == null)
                    throw new ArgumentException("You may only set properties of a Vector to another Vector of the same type.");
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
