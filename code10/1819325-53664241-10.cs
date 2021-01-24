     private static void WriteStruct<T>(this BinaryWriter writer, T obj) where T : struct {
         var len = Marshal.SizeOf(typeof(T));
         var buffer = new byte[len];
         GCHandle handle = default(GCHandle);
         try {
             handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
             Marshal.StructureToPtr(obj, handle.AddrOfPinnedObject(), false);
         } finally {
             if (handle.IsAllocated)
                 handle.Free();
         }
         writer.Write(buffer);
     }
