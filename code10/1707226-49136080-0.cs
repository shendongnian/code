    System.IO.DriveType driveType = drive.DriveType;
    switch (driveType)
    {
        case System.IO.DriveType.CDRom:
            break;
        case System.IO.DriveType.Fixed:
            // Local Drive
            break;
        case System.IO.DriveType.Network:
            // Mapped Drive
            break;
        case System.IO.DriveType.NoRootDirectory:
            break;
        case System.IO.DriveType.Ram:
            break;
        case System.IO.DriveType.Removable:
            // Usually a USB Drive
            break;
        case System.IO.DriveType.Unknown:
            break;
    }
