    using System;
    using System.Runtime.InteropServices;
    using System.IO;
    using System.Diagnostics;
    
    // Use LayoutKind.Sequential to prevent the CLR from reordering your fields.
    [StructLayout(LayoutKind.Sequential)]
    unsafe struct MeshDesc
    {
        public byte NameLen;
        // Here fixed means store the array by value, like in C,
        // though C# exposes access to Name as a char*.
        // fixed also requires 'unsafe' on the struct definition.
        public fixed char Name[16];
        // You can include other structs like in C as well.
        public Matrix Transform;
        public uint VertexCount;
        // But not both, you can't store an array of structs.
        //public fixed Vector Vertices[512];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    unsafe struct Matrix
    {
        public fixed float M[16];
    }
    
    // This is how you do unions
    [StructLayout(LayoutKind.Explicit)]
    unsafe struct Vector
    {
        [FieldOffset(0)]
        public fixed float Items[16];
        [FieldOffset(0)]
        public float X;
        [FieldOffset(4)]
        public float Y;
        [FieldOffset(8)]
        public float Z;
    }
    
    class Program
    {
        unsafe static void Main(string[] args)
        {
            var mesh = new MeshDesc();
            var buffer = new byte[Marshal.SizeOf(mesh)];
    
            // Set where NameLen will be read from.
            buffer[0] = 12;
            // Use Buffer.BlockCopy to raw copy data across arrays of primitives.
            // Note we copy to offset 2 here: char's have alignment of 2, so there is
            // a padding byte after NameLen: just like in C.
            Buffer.BlockCopy("Hello!".ToCharArray(), 0, buffer, 2, 12);
    
            // Copy data to struct
            Read(buffer, out mesh);
    
            // Print the Name we wrote above:
            var name = new char[mesh.NameLen];
            // Use Marsal.Copy to copy between arrays and pointers to arrays.
            unsafe { Marshal.Copy((IntPtr)mesh.Name, name, 0, mesh.NameLen); }
            // Note you can also use the String.String(char*) overloads
            Console.WriteLine("Name: " + new string(name));
    
            // If Erik Myers likes it...
            mesh.VertexCount = 4711;
    
            // Copy data from struct:
            // MeshDesc is a struct, and is on the stack, so it's
            // memory is effectively pinned by the stack pointer.
            // This means '&' is sufficient to get a pointer.
            Write(&mesh, buffer);
    
            // Watch for alignment again, and note you have endianess to worry about...
            int vc = buffer[100] | (buffer[101] << 8) | (buffer[102] << 16) | (buffer[103] << 24);
            Console.WriteLine("VertexCount = " + vc);
        }
    
        unsafe static void Write(MeshDesc* pMesh, byte[] buffer)
        {
            // But byte[] is on the heap, and therefore needs
            // to be flagged as pinned so the GC won't try to move it
            // from under you - this can be done most efficiently with
            // 'fixed', but can also be done with GCHandleType.Pinned.
            fixed (byte* pBuffer = buffer)
                *(MeshDesc*)pBuffer = *pMesh;
        }
    
        unsafe static void Read(byte[] buffer, out MeshDesc mesh)
        {
            fixed (byte* pBuffer = buffer)
                mesh = *(MeshDesc*)pBuffer;
        }
    }
