    public static Icon IconFromExtension(string extension, SystemIconSize size)
      {
         if (extension[0] != '.') extension = '.' + extension;
         object obj;
         shell.AssocCreate(shell.CLSID_QueryAssociations, ref shell.IID_IQueryAssociations, out obj);
         var qa = (shell.IQueryAssociations)obj;
         qa.Init(shell.ASSOCF.INIT_DEFAULTTOSTAR, Convert.ToString(extension), UIntPtr.Zero, IntPtr.Zero);
         var bufSize = 0;
         qa.GetString(shell.ASSOCF.NOTRUNCATE, shell.ASSOCSTR.DEFAULTICON, null, null, ref bufSize);
         var sb = new StringBuilder(bufSize);
         qa.GetString(shell.ASSOCF.NOTRUNCATE, shell.ASSOCSTR.DEFAULTICON, null, sb, ref bufSize);
         if (!String.IsNullOrEmpty(sb.ToString()))
         {
            var iconLocation = sb.ToString();
            var iconPath = iconLocation.Split(',');
            var iIconPathNumber = iconPath.Length > 1 ? 1 : 0;
            if (iconPath[iIconPathNumber] == null) iconPath[iIconPathNumber] = "0";
            var large = new IntPtr[1];
            var small = new IntPtr[1];
            //extracts the icon from the file.
            ExtractIconEx(iconPath[0],
                          iIconPathNumber > 0 ? Convert.ToInt16(iconPath[iIconPathNumber]) : Convert.ToInt16(0),
                          large,
                          small, 1);
            return size == SystemIconSize.Large
                      ? Icon.FromHandle(large[0])
                      : Icon.FromHandle(small[0]);
         }
         return IntPtr.Zero;
      }
