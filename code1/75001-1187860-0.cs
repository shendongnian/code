    // ...
    private static IEnumerable<IVirtualItem> GetDataObjectContent(System.Windows.Forms.IDataObject dataObject)
    {
      if (dataObject == null)
        return null;
      List<IVirtualItem> Result = new List<IVirtualItem>();
      bool WideDescriptor = dataObject.GetDataPresent(ShlObj.CFSTR_FILEDESCRIPTORW);
      bool AnsiDescriptor = dataObject.GetDataPresent(ShlObj.CFSTR_FILEDESCRIPTORA);
      if (WideDescriptor || AnsiDescriptor)
      {
        IDataObject NativeDataObject = dataObject as IDataObject;
        if (NativeDataObject != null)
        {
          object Data = null;
          if (WideDescriptor)
            Data = dataObject.GetData(ShlObj.CFSTR_FILEDESCRIPTORW);
          else
            if (AnsiDescriptor)
              Data = dataObject.GetData(ShlObj.CFSTR_FILEDESCRIPTORA);
          Stream DataStream = Data as Stream;
          if (DataStream != null)
          {
            Dictionary<string, VirtualClipboardFolder> FolderMap =
              new Dictionary<string, VirtualClipboardFolder>(StringComparer.OrdinalIgnoreCase);
            BinaryReader Reader = new BinaryReader(DataStream);
            int Count = Reader.ReadInt32();
            for (int I = 0; I < Count; I++)
            {
              VirtualClipboardItem ClipboardItem;
              if (WideDescriptor)
              {
                FILEDESCRIPTORW Descriptor = ByteArrayHelper.ReadStructureFromStream<FILEDESCRIPTORW>(DataStream);
                if (((Descriptor.dwFlags & FD.FD_ATTRIBUTES) > 0) && ((Descriptor.dwFileAttributes & FileAttributes.Directory) > 0))
                  ClipboardItem = new VirtualClipboardFolder(Descriptor);
                else
                  ClipboardItem = new VirtualClipboardFile(Descriptor, NativeDataObject, I);
              }
              else
              {
                FILEDESCRIPTORA Descriptor = ByteArrayHelper.ReadStructureFromStream<FILEDESCRIPTORA>(DataStream);
                if (((Descriptor.dwFlags & FD.FD_ATTRIBUTES) > 0) && ((Descriptor.dwFileAttributes & FileAttributes.Directory) > 0))
                  ClipboardItem = new VirtualClipboardFolder(Descriptor);
                else
                  ClipboardItem = new VirtualClipboardFile(Descriptor, NativeDataObject, I);
              }
              string ParentFolder = Path.GetDirectoryName(ClipboardItem.FullName);
              if (string.IsNullOrEmpty(ParentFolder))
                Result.Add(ClipboardItem);
              else
              {
                VirtualClipboardFolder Parent = FolderMap[ParentFolder];
                ClipboardItem.Parent = Parent;
                Parent.Content.Add(ClipboardItem);
              }
              VirtualClipboardFolder ClipboardFolder = ClipboardItem as VirtualClipboardFolder;
              if (ClipboardFolder != null)
                FolderMap.Add(PathHelper.ExcludeTrailingDirectorySeparator(ClipboardItem.FullName), ClipboardFolder);
            }
          }
        }
      }
      return Result.Count > 0 ? Result : null;
    }
    // ...
    public VirtualClipboardFile : VirtualClipboardItem, IVirtualFile
    {
      // ...
    public Stream Open(FileMode mode, FileAccess access, FileShare share, FileOptions options, long startOffset)
    {
      if ((mode != FileMode.Open) || (access != FileAccess.Read))
        throw new ArgumentException("Only open file mode and read file access supported.");
      System.Windows.Forms.DataFormats.Format Format = System.Windows.Forms.DataFormats.GetFormat(ShlObj.CFSTR_FILECONTENTS);
      if (Format == null)
        return null;
      FORMATETC FormatEtc = new FORMATETC();
      FormatEtc.cfFormat = (short)Format.Id;
      FormatEtc.dwAspect = DVASPECT.DVASPECT_CONTENT;
      FormatEtc.lindex = FIndex;
      FormatEtc.tymed = TYMED.TYMED_ISTREAM | TYMED.TYMED_HGLOBAL;
      STGMEDIUM Medium;
      FDataObject.GetData(ref FormatEtc, out Medium);
      try
      {
        switch (Medium.tymed)
        {
          case TYMED.TYMED_ISTREAM:
            IStream MediumStream = (IStream)Marshal.GetTypedObjectForIUnknown(Medium.unionmember, typeof(IStream));
            ComStreamWrapper StreamWrapper = new ComStreamWrapper(MediumStream, FileAccess.Read, ComRelease.None);
            // Seek from beginning
            if (startOffset > 0)
              if (StreamWrapper.CanSeek)
                StreamWrapper.Seek(startOffset, SeekOrigin.Begin);
              else
              {
                byte[] Null = new byte[256];
                int Readed = 1;
                while ((startOffset > 0) && (Readed > 0))
                {
                  Readed = StreamWrapper.Read(Null, 0, (int)Math.Min(Null.Length, startOffset));
                  startOffset -= Readed;
                }
              }
            StreamWrapper.Closed += delegate(object sender, EventArgs e)
            {
              ActiveX.ReleaseStgMedium(ref Medium);
              Marshal.FinalReleaseComObject(MediumStream);
            };
            return StreamWrapper;
          case TYMED.TYMED_HGLOBAL:
            byte[] FileContent;
            IntPtr MediumLock = Windows.GlobalLock(Medium.unionmember);
            try
            {
              long Size = FSize.HasValue ? FSize.Value : Windows.GlobalSize(MediumLock).ToInt64();
              FileContent = new byte[Size];
              Marshal.Copy(MediumLock, FileContent, 0, (int)Size);
            }
            finally
            {
              Windows.GlobalUnlock(Medium.unionmember);
            }
            ActiveX.ReleaseStgMedium(ref Medium);
            Stream ContentStream = new MemoryStream(FileContent, false);
            ContentStream.Seek(startOffset, SeekOrigin.Begin);
            return ContentStream;
          default:
            throw new ApplicationException(string.Format("Unsupported STGMEDIUM.tymed ({0})", Medium.tymed));
        }
      }
      catch
      {
        ActiveX.ReleaseStgMedium(ref Medium);
        throw;
      }
    }
    // ...
