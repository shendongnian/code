    public static class NativeMethods
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA5122:PInvokesShouldNotBeSafeCriticalFxCopRule", Justification = "Warning is bogus.")]
        [DllImport("virtdisk.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 OpenVirtualDisk(ref VIRTUAL_STORAGE_TYPE VirtualStorageType, 
            string Path, 
            VIRTUAL_DISK_ACCESS_MASK VirtualDiskAccessMask, 
            OPEN_VIRTUAL_DISK_FLAG Flags, 
            ref OPEN_VIRTUAL_DISK_PARAMETERS Parameters, 
            ref VirtualDiskSafeHandle Handle);
        public static readonly Guid VIRTUAL_STORAGE_TYPE_VENDOR_MICROSOFT = new Guid("EC984AEC-A0F9-47e9-901F-71415A66345B");
        public const int OPEN_VIRTUAL_DISK_RW_DEPTH_DEFAULT = 1;
        public const Int32 ERROR_SUCCESS = 0;
        public const Int32 ERROR_FILE_CORRUPT = 1392;
        public const Int32 ERROR_FILE_NOT_FOUND = 2;
        public const Int32 ERROR_PATH_NOT_FOUND = 3;
        public const Int32 ERROR_ACCESS_DENIED = 5;
        /// CD or DVD image file device type. (.iso file)
        /// </summary>
        public const int VIRTUAL_STORAGE_TYPE_DEVICE_ISO = 1;
        /// <summary>
        /// Device type is unknown or not valid.
        /// </summary>
        public const int VIRTUAL_STORAGE_TYPE_DEVICE_UNKNOWN = 0;
        /// <summary>
        /// Virtual hard disk device type. (.vhd file)
        /// </summary>
        public const int VIRTUAL_STORAGE_TYPE_DEVICE_VHD = 2;
        /// <summary>
        /// VHDX format virtual hard disk device type. (.vhdx file)
        /// </summary>
        public const int VIRTUAL_STORAGE_TYPE_DEVICE_VHDX = 3;
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct VIRTUAL_STORAGE_TYPE
        {
            /// <summary>
            /// Device type identifier.
            /// </summary>
            public Int32 DeviceId; //ULONG
            /// <summary>
            /// Vendor-unique identifier.
            /// </summary>
            public Guid VendorId; //GUID
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct OPEN_VIRTUAL_DISK_PARAMETERS
        {
            /// <summary>
            /// An OPEN_VIRTUAL_DISK_VERSION enumeration that specifies the version of the OPEN_VIRTUAL_DISK_PARAMETERS structure being passed to or from the VHD functions.
            /// </summary>
            public OPEN_VIRTUAL_DISK_VERSION Version; //OPEN_VIRTUAL_DISK_VERSION
            /// <summary>
            /// A structure.
            /// </summary>
            public OPEN_VIRTUAL_DISK_PARAMETERS_Version1 Version1;
        }
        public enum OPEN_VIRTUAL_DISK_VERSION : int
        {
            /// <summary>
            /// </summary>
            OPEN_VIRTUAL_DISK_VERSION_UNSPECIFIED = 0,
            /// <summary>
            /// </summary>
            OPEN_VIRTUAL_DISK_VERSION_1 = 1
        }
        [Flags]
        public enum VirtualDiskAccessMask : int
        {
            /// <summary>
            /// Open the virtual disk for read-only attach access. The caller must have READ access to the virtual disk image file. If used in a request to open a virtual disk that is already open, the other handles must be limited to either VIRTUAL_DISK_ACCESS_DETACH or VIRTUAL_DISK_ACCESS_GET_INFO access, otherwise the open request with this flag will fail.
            /// </summary>
            AttachReadOnly = 0x00010000,
            /// <summary>
            /// Open the virtual disk for read-write attaching access. The caller must have (READ | WRITE) access to the virtual disk image file. If used in a request to open a virtual disk that is already open, the other handles must be limited to either VIRTUAL_DISK_ACCESS_DETACH or VIRTUAL_DISK_ACCESS_GET_INFO access, otherwise the open request with this flag will fail. If the virtual disk is part of a differencing chain, the disk for this request cannot be less than the RWDepth specified during the prior open request for that differencing chain.
            /// </summary>
            AttachReadWrite = 0x00020000,
            /// <summary>
            /// Open the virtual disk to allow detaching of an attached virtual disk. The caller must have (FILE_READ_ATTRIBUTES | FILE_READ_DATA) access to the virtual disk image file.
            /// </summary>
            Detach = 0x00040000,
            /// <summary>
            /// Information retrieval access to the VHD. The caller must have READ access to the virtual disk image file.
            /// </summary>
            GetInfo = 0x00080000,
            /// <summary>
            /// VHD creation access.
            /// </summary>
            Create = 0x00100000,
            /// <summary>
            /// Open the VHD to perform offline meta-operations. The caller must have (READ | WRITE) access to the virtual disk image file, up to RWDepth if working with a differencing chain. If the VHD is part of a differencing chain, the backing store (host volume) is opened in RW exclusive mode up to RWDepth.
            /// </summary>
            MetaOperations = 0x00200000,
            /// <summary>
            /// Allows unrestricted access to the VHD. The caller must have unrestricted access rights to the virtual disk image file.
            /// </summary>
            All = 0x003f0000,
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct OPEN_VIRTUAL_DISK_PARAMETERS_Version1
        {
            /// <summary>
            /// Indicates the number of stores, beginning with the child, of the backing store chain to open as read/write. The remaining stores in the differencing chain will be opened read-only. This is necessary for merge operations to succeed.
            /// </summary>
            public Int32 RWDepth; //ULONG
        }
        public enum OPEN_VIRTUAL_DISK_FLAG : int
        {
            /// <summary>
            /// No flag specified.
            /// </summary>
            OPEN_VIRTUAL_DISK_FLAG_NONE = 0x00000000,
            /// <summary>
            /// Open the backing store without opening any differencing-chain parents. Used to correct broken parent links.
            /// </summary>
            OPEN_VIRTUAL_DISK_FLAG_NO_PARENTS = 0x00000001,
            /// <summary>
            /// Reserved.
            /// </summary>
            OPEN_VIRTUAL_DISK_FLAG_BLANK_FILE = 0x00000002,
            /// <summary>
            /// Reserved.
            /// </summary>
            OPEN_VIRTUAL_DISK_FLAG_BOOT_DRIVE = 0x00000004
        }
        public enum VIRTUAL_DISK_ACCESS_MASK : int
        {
            /// <summary>
            /// Open the virtual disk for read-only attach access. The caller must have READ access to the virtual disk image file. If used in a request to open a virtual disk that is already open, the other handles must be limited to either VIRTUAL_DISK_ACCESS_DETACH or VIRTUAL_DISK_ACCESS_GET_INFO access, otherwise the open request with this flag will fail.
            /// </summary>
            VIRTUAL_DISK_ACCESS_ATTACH_RO = 0x00010000,
            /// <summary>
            /// Open the virtual disk for read-write attaching access. The caller must have (READ | WRITE) access to the virtual disk image file. If used in a request to open a virtual disk that is already open, the other handles must be limited to either VIRTUAL_DISK_ACCESS_DETACH or VIRTUAL_DISK_ACCESS_GET_INFO access, otherwise the open request with this flag will fail. If the virtual disk is part of a differencing chain, the disk for this request cannot be less than the RWDepth specified during the prior open request for that differencing chain.
            /// </summary>
            VIRTUAL_DISK_ACCESS_ATTACH_RW = 0x00020000,
            /// <summary>
            /// Open the virtual disk to allow detaching of an attached virtual disk. The caller must have (FILE_READ_ATTRIBUTES | FILE_READ_DATA) access to the virtual disk image file.
            /// </summary>
            VIRTUAL_DISK_ACCESS_DETACH = 0x00040000,
            /// <summary>
            /// Information retrieval access to the VHD. The caller must have READ access to the virtual disk image file.
            /// </summary>
            VIRTUAL_DISK_ACCESS_GET_INFO = 0x00080000,
            /// <summary>
            /// VHD creation access.
            /// </summary>
            VIRTUAL_DISK_ACCESS_CREATE = 0x00100000,
            /// <summary>
            /// Open the VHD to perform offline meta-operations. The caller must have (READ | WRITE) access to the virtual disk image file, up to RWDepth if working with a differencing chain. If the VHD is part of a differencing chain, the backing store (host volume) is opened in RW exclusive mode up to RWDepth.
            /// </summary>
            VIRTUAL_DISK_ACCESS_METAOPS = 0x00200000,
            /// <summary>
            /// Reserved.
            /// </summary>
            VIRTUAL_DISK_ACCESS_READ = 0x000d0000,
            /// <summary>
            /// Allows unrestricted access to the VHD. The caller must have unrestricted access rights to the virtual disk image file.
            /// </summary>
            VIRTUAL_DISK_ACCESS_ALL = 0x003f0000,
            /// <summary>
            /// Reserved.
            /// </summary>
            VIRTUAL_DISK_ACCESS_WRITABLE = 0x00320000
        }
    }
    [SecurityPermission(SecurityAction.Demand)]
    public class VirtualDiskSafeHandle : SafeHandle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA5122:PInvokesShouldNotBeSafeCriticalFxCopRule", Justification = "Warning is bogus.")]
        [DllImportAttribute("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        public static extern Boolean CloseHandle(IntPtr hObject);
        public VirtualDiskSafeHandle()
            : base(IntPtr.Zero, true)
        {
        }
        public override bool IsInvalid
        {
            get { return (this.IsClosed) || (base.handle == IntPtr.Zero); }
        }
        public override string ToString()
        {
            return this.handle.ToString();
        }
        protected override bool ReleaseHandle()
        {
            return CloseHandle(handle);
        }
        public IntPtr Handle
        {
            get { return handle; }
        }
    }
