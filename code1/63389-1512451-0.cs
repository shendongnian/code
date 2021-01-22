        public unsafe static T[] Create<T>(void* source, int length)
        {
            var type = typeof(T);
            var sizeInBytes =  Marshal.SizeOf(typeof(T));
                
            T[] output = new T[length];
            if (type.IsPrimitive)
            {
                // Make sure the array won't be moved around by the GC 
                var handle = GCHandle.Alloc(output, GCHandleType.Pinned);
                var destination = (byte*)handle.AddrOfPinnedObject().ToPointer();
                var byteLength = length * sizeInBytes;
                // There are faster ways to do this, particularly by using wider types or by 
                // handling special lengths.
                for (int i = 0; i < byteLength; i++)
                    destination[i] = ((byte*)source)[i];
                handle.Free();
            }
            else if (type.IsValueType)
            {
                if (!type.IsLayoutSequential && !type.IsExplicitLayout)
                {
                    throw new InvalidOperationException(string.Format("{0} does not define a StructLayout attribute", type));
                }
                IntPtr sourcePtr = new IntPtr(source);
                for (int i = 0; i < length; i++)
                {
                    IntPtr p = new IntPtr((byte*)source + i * sizeInBytes);
                    output[i] = (T)System.Runtime.InteropServices.Marshal.PtrToStructure(p, typeof(T));
                }
            }
            else 
            {
                throw new InvalidOperationException(string.Format("{0} is not supported", type));
            }
            return output;
        }
        unsafe static void Main(string[] args)
        {
            var arrayDouble = Enumerable.Range(1, 1024)
                                        .Select(i => (double)i)
                                        .ToArray();
            fixed (double* p = arrayDouble)
            {
                var array2 = Create<double>(p, arrayDouble.Length);
                Assert.AreEqual(arrayDouble, array2);
            }
            var arrayPoint = Enumerable.Range(1, 1024)
                                       .Select(i => new Point(i, i * 2 + 1))
                                       .ToArray();
            fixed (Point* p = arrayPoint)
            {
                var array2 = Create<Point>(p, arrayPoint.Length);
                Assert.AreEqual(arrayPoint, array2);
            }
        }
