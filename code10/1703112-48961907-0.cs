    case Iso9660Variant.Joliet:
        if (svdPos != 0) // <-- Joliet is always a supplementary table.
        {
            data.Position = svdPos;
            data.Read(buffer, 0, IsoUtilities.SectorSize);
            SupplementaryVolumeDescriptor volDesc = new SupplementaryVolumeDescriptor(buffer, 0);
    
            Context = new IsoContext { VolumeDescriptor = volDesc, DataStream = _data };
            RootDirectory = new ReaderDirectory(Context,
                new ReaderDirEntry(Context, volDesc.RootDirectory));
            ActiveVariant = Iso9660Variant.Iso9660; // <-- set active variant to base Iso9660
        }
    
        break;
