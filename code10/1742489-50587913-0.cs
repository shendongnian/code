    public struct OrderStruct
    {
        public const int SIZE = 16;
        public int AssetId;
        public int OrderQty;
        public double Price;
        public static OrderStruct FromBytes(byte[] data)
        {
            if (data.Length < SIZE)
                throw new ArgumentException("Size is incorrect");
            GCHandle h = default(GCHandle);
            try
            {
                try
                {
                }
                finally
                {
                    h = GCHandle.Alloc(data, GCHandleType.Pinned);
                }
                OrderStruct t = Marshal.PtrToStructure<OrderStruct>(h.AddrOfPinnedObject());
                return t;
            }
            finally
            {
                if (h.IsAllocated)
                {
                    h.Free();
                }
            }
        }
        public byte[] ToBytes()
        {
            var result = new byte[SIZE];
            GCHandle h = default(GCHandle);
            try
            {
                try
                {
                }
                finally
                {
                    h = GCHandle.Alloc(result, GCHandleType.Pinned);
                }
                Marshal.StructureToPtr(this, h.AddrOfPinnedObject(), false);
                return result;
            }
            finally
            {
                if (h.IsAllocated)
                {
                    h.Free();
                }
            }
        }
    }
