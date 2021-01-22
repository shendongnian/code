    unsafe sealed class FixedFloatArray : IDisposable {
        readonly float* _floats;
        internal FixedFloatArray(int size) {
            _floats = (float*)Marshal.AllocHGlobal(sizeof(float) * size);
        }
        internal FixedFloatArray(float[] floats) {
            _floats = (float*)Marshal.AllocHGlobal(sizeof(float) * floats.Length);
            Marshal.Copy(floats, 0, (IntPtr)_floats, floats.Length);
        }
        internal float this[int i] {
            get { return _floats[i]; }
            set { _floats[i] = value; }
        }
        internal void CopyFrom(float[] source, int sourceIndex, int destinationIndex, int length) {
            var memoryOffset = (int)_floats + destinationIndex * sizeof(float);
            Marshal.Copy(source, sourceIndex, (IntPtr)memoryOffset, length);
        }
        internal void CopyTo(int sourceIndex, float[] destination, int destinationIndex, int length) {
            var memoryOffset = (int)_floats + sourceIndex * sizeof(float);
            Marshal.Copy((IntPtr)memoryOffset, destination, destinationIndex, length);
        }
        public static implicit operator IntPtr(FixedFloatArray ffa) {
            return (IntPtr)ffa._floats;
        }
        public void Dispose() {
            Marshal.FreeHGlobal((IntPtr)_floats);
        }
    }
