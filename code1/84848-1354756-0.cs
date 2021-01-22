    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Size = 96, Pack = 1)]
    public unsafe struct Fat32BootSector
    {
        #region Common Region With all FAT systems
        /// <summary>
        /// First 3 Bytes of the Jump insctructions.
        /// Offset 0x00 	
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        [FieldOffset(0x00)]
        public fixed byte JumpBootInstructions[3];
        /// <summary>
        /// 8 Bytes of the OemName
        /// Offset 0x03
        /// </summary>
        [FieldOffset(0x03)]
        public fixed char OemName[8];
        #region BIOS Parameter Block (BPB)
        /// <summary>
        /// 2 Bytes of the BytesPerSector parameter. The BIOS Paramter Block Starts here
        /// Offset 0x0b 	
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
        [FieldOffset(0x0b)]
        public ushort BpbBytesPerSector;
        /// <summary>
        /// 1 Byte containing the number of sectors per cluster. This must be a power of 2 from 1 to 128
        /// Offset 0x0d
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(0x0d)]
        public byte BpbSectorsPerCluster;
        /// <summary>
        /// 2 Bytes for the Bpb reserved sectors count, Usually 32 for FAT32.
        /// Offset 0x0e 	
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
        [FieldOffset(0x0e)]
        public ushort BpbReservedSectorsCount;
        /// <summary>
        /// 1 Byte Number of file allocation tables. Almost always 2.
        /// Offset 0x10
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(0x10)]
        public byte BpbFatCount;
        /// <summary>
        /// 2 Bytes, Maximum number of root directory entries. Only used on FAT12 and FAT16
        /// Offset 0x11
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
        [FieldOffset(0x11)]
        public ushort BpbMaxRootDirectoriesCount;
        /// <summary>
        /// 2 Bytes, Total sectors (if zero, use 4 byte value at offset 0x20) used only for FAT12 AND FAT16 Systems
        /// Offset 0x13 	
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
        [FieldOffset(0x13)]
        public ushort BpbTotalSectors16;
        /// <summary>
        /// 1 Byte, the media descriptor 
        /// Offset 0x15
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(0x15)]
        public MediaDescriptor BpbMediaDescriptor;
        /// <summary>
        /// 2 Bytes, Sectors per File Allocation Table for FAT12/FAT16
        /// Offset 0x16
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
        [FieldOffset(0x16)]
        public ushort BpbSectorsPerFat16;
        /// <summary>
        /// 2 Bytes, Sectors per track
        /// Offset 0x18
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
        [FieldOffset(0x18)]
        public ushort BpbSectorsPerTrack;
        /// <summary>
        /// 2 Bytes Number of heads.
        /// Offset 0x1a
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
        [FieldOffset(0x1a)]
        public ushort BpbNumberOfHeads;
        /// <summary>
        /// 4 Bytes Hidden sectors.
        /// Offset 0x1c
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        [FieldOffset(0x1c)]
        public uint BpbHiddenSectors;
        /// <summary>
        /// 4 Bytes, Total sectors (if greater than 65535; otherwise, see offset 0x13)
        /// Offset 0x20
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        [FieldOffset(0x20)]
        public uint BpbTotalSectors32;
        #endregion
        #endregion
        #region Extended BIOS Parameter Block: FAT32 Specific
        /// <summary>
        /// 4 Bytes for the number of sectors occupied by ONE FAT. 
        /// Offset 0x24
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        [FieldOffset(0x24)]
        public uint FatSize32;
        /// <summary>
        /// 2 Bytes
        /// This field is only defined for FAT32 media and does not exist on FAT12 and FAT16 media.
        /// Bits 0-3	-- Zero-based number of active FAT. Only valid if mirroring is disabled.
        /// Bits 4-6	-- Reserved.
        /// Bit  7	    -- 0 means the FAT is mirrored at runtime into all FATs.
        ///             -- 1 means only one FAT is active; it is the one referenced in bits 0-3.
        /// Bits 8-15 	-- Reserved.
        /// Offset 0x28
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
        [FieldOffset(0x28)]
        public ushort ExtendedFlags;
        /// <summary>
        /// 2 Bytes for the file system version. The high byte is major revision number. Low byte is minor revision number. 
        /// Offset 0x2a
        /// </summary>
        [FieldOffset(0x2a)]
        public fixed byte FileSystemVersion[2];
        /// <summary>
        /// 4 Bytes for the first cluster number of the root directory
        /// Offset 0x2c
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        [FieldOffset(0x2c)]
        public uint RootDirFirstClusterNumber;
        /// <summary>
        /// 2 Bytes for the Sector number of FS Information Sector.
        /// Offset 0x30
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
        [FieldOffset(0x30)]
        public ushort FSInfoSectorNumber;
        /// <summary>
        /// 2 Bytes. If non-zero, indicates the sector number in the reserved area of the volume of a copy of the boot record. Usually 6.
        /// Offset 0x32
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
        [FieldOffset(0x32)]
        public ushort BackupBootSectorNumber;
        /// <summary>
        /// 12 Reserved Bytes.
        /// Offset 0x34
        /// </summary>
        [FieldOffset(0x34)]
        public fixed byte Reserved[12];
        /// <summary>
        /// 1 Byte for the physical drive number.
        /// Offset 0x40
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(0x40)]
        public byte PhysicalDriveNumber;
        /// <summary>
        /// 1 Reserved byte.
        /// Offset 0x41
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(0x41)]
        public byte Reserved1;
        /// <summary>
        /// 1 Byte. The boot signature
        /// Offset 0x42
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(0x42)]
        public byte ExtendedBootSignature;
        /// <summary>
        /// 4 Bytes for the volume serial number.
        /// Offset 0x43
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        [FieldOffset(0x43)]
        public uint VolumeID;
        /// <summary>
        /// 11 Byte for the volume label.
        /// Offset 0x47
        /// </summary>
        [FieldOffset(0x47)]
        public fixed char VolumeLabel[11];
        /// <summary>
        /// 8 Bytes for the file system type string. 
        /// Offset 0x52
        /// </summary>
        [FieldOffset(0x52)]
        public fixed char FileSystemType[8];
        #endregion
        /// <summary>
        /// Gets the boot sector for the specified drive.
        /// <remarks>The drive letter must have this pattern X: </remarks>
        /// </summary>
        /// <param name="driveLetter">The </param>
        /// <returns>The boot sector for the specified drive.</returns>
        public static Fat32BootSector GetBootSectorForDrive(string driveLetter)
        {
            byte[] bootSector = new byte[Marshal.SizeOf(typeof(Fat32BootSector))];
            string drive = @"\\.\" + driveLetter;
            IntPtr hardDiskPointer = SystemIOCalls.OpenFile(drive);
            // Seeks to the start of the partition
            SystemIOCalls.SeekAbsolute(hardDiskPointer, 0, 0);
            // Read the first reserved sector of the drive data (Boot Sector)
            // The data should be read with a chunk of 512 X byte.
            SystemIOCalls.ReadBytes(hardDiskPointer, bootSector, 512);
            SystemIOCalls.CloseHandle(hardDiskPointer);
            // Marshaling the bytes array to a valid struct
            GCHandle pinnedInfos = GCHandle.Alloc(bootSector, GCHandleType.Pinned);
            var infos = (Fat32BootSector)Marshal.PtrToStructure(pinnedInfos.AddrOfPinnedObject(), typeof(Fat32BootSector));
            pinnedInfos.Free();
            return infos;
        }
    }
}
