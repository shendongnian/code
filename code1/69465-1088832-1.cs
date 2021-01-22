    internal class NativeMethods
    {
        /// <summary>
        /// The type of structure that the function stores in the buffer.
        /// </summary>
        public enum InfoLevel
        {
            /// <summary>
            /// The function stores a <see cref="UNIVERSAL_NAME_INFO"/> structure in the
            /// buffer.
            /// </summary>
            UniversalName = 1,
            /// <summary>
            /// The function stores a <c>REMOTE_NAME_INFO</c> structure in the buffer.
            /// </summary>
            /// <remarks>
            /// Using this level will throw an <see cref="NotSupportedException"/>.
            /// </remarks>
            RemoteName = 2
        }
        /// <summary>
        /// The <see cref="WNetGetUniversalName(string,int,UNIVERSAL_NAME_INFO,int)"/> function
        /// takes a drive-based path for a network resource and returns an information
        /// structure that contains a more universal form of the name.
        /// </summary>
        /// <param name="lpLocalPath">A pointer to a constant null-terminated string that
        /// is a drive-based path for a network resource.</param>
        /// <param name="dwInfoLevel">The type of structure that the function stores in
        /// the buffer pointed to by the <paramref name="lpBuffer"/> parameter.</param>
        /// <param name="lpBuffer">A pointer to a buffer that receives the structure
        /// specified by the <paramref name="dwInfoLevel"/> parameter.</param>
        /// <param name="lpBufferSize">A pointer to a variable that specifies the size,
        /// in bytes, of the buffer pointed to by the <paramref name="lpBuffer"/> parameter.</param>
        /// <returns>If the function succeeds, the return value is <see cref="NO_ERROR"/>.</returns>
        [DllImport("mpr.dll", CharSet = CharSet.Auto)]
        public static extern int WNetGetUniversalName(
            string lpLocalPath,
            InfoLevel dwInfoLevel,
            ref UNIVERSAL_NAME_INFO lpBuffer,
            ref int lpBufferSize);
        /// <summary>
        /// The <see cref="WNetGetUniversalName(string,int,IntPtr,int)"/> function
        /// takes a drive-based path for a network resource and returns an information
        /// structure that contains a more universal form of the name.
        /// </summary>
        /// <param name="lpLocalPath">A pointer to a constant null-terminated string that
        /// is a drive-based path for a network resource.</param>
        /// <param name="dwInfoLevel">The type of structure that the function stores in
        /// the buffer pointed to by the <paramref name="lpBuffer"/> parameter.</param>
        /// <param name="lpBuffer">A pointer to a buffer that receives the structure
        /// specified by the <paramref name="dwInfoLevel"/> parameter.</param>
        /// <param name="lpBufferSize">A pointer to a variable that specifies the size,
        /// in bytes, of the buffer pointed to by the <paramref name="lpBuffer"/> parameter.</param>
        /// <returns>If the function succeeds, the return value is <see cref="NO_ERROR"/>.</returns>
        [DllImport("mpr.dll", CharSet = CharSet.Auto)]
        public static extern int WNetGetUniversalName(
            string lpLocalPath,
            InfoLevel dwInfoLevel,
            IntPtr lpBuffer,
            ref int lpBufferSize);
        /// <summary>
        /// The <see cref="UNIVERSAL_NAME_INFO"/> structure contains a pointer to a
        /// Universal Naming Convention (UNC) name string for a network resource.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct UNIVERSAL_NAME_INFO
        {
            /// <summary>
            /// Pointer to the null-terminated UNC name string that identifies a
            /// network resource.
            /// </summary>
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpUniversalName;
        }
    }
