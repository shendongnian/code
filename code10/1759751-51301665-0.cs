        static ImmutableArray<T> HackyMakeImmutable<T>(T[] array)
        {
            var arrayObject = (object)new HackImmutableArray<T> { Array = array };
            var handle = GCHandle.Alloc(arrayObject, GCHandleType.Pinned);
            var immutable = (ImmutableArray<T>)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return immutable;
        }
