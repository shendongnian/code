      /// <summary>
      /// Method to get the Subversion revision number for the top folder of the build collection, 
      /// assuming these files were checked-out from Merlinia's Subversion repository. This also 
      /// checks that the working copy is up-to-date. (This does require that a connection to the 
      /// Subversion repository is possible, and that it is running.)
      /// 
      /// One minor problem is that SharpSvn is available in 32-bit or 64-bit DLLs, so the program 
      /// needs to target one or the other platform, not "Any CPU".
      /// 
      /// On error an exception is thrown; caller must be prepared to catch it.
      /// </summary>
      /// <returns>Subversion repository revision number</returns>
      private int GetSvnRevisionNumber()
      {
         try
         {
            // Get the latest revision number from the Subversion repository
            SvnInfoEventArgs svnInfoEventArgs;
            using (SvnClient svnClient = new SvnClient())
            {
               svnClient.GetInfo(new Uri("svn://99.99.99.99/Merlinia/Trunk"), out svnInfoEventArgs);
            }
            // Get the current revision numbers from the working copy that is the "build collection"
            SvnWorkingCopyVersion svnWorkingCopyVersion;
            using (SvnWorkingCopyClient svnWorkingCopyClient = new SvnWorkingCopyClient())
            {
               svnWorkingCopyClient.GetVersion(_collectionFolder, out svnWorkingCopyVersion);
            }
            // Check the build collection has not been modified since last commit or update
            if (svnWorkingCopyVersion.Modified)
            {
               throw new MerliniaException(0x3af34e1u, 
                      "Build collection has been modified since last repository commit or update.");
            }
            // Check the build collection is up-to-date relative to the repository
            if (svnInfoEventArgs.Revision != svnWorkingCopyVersion.Start)
            {
               throw new MerliniaException(0x3af502eu, 
                 "Build collection not up-to-date, its revisions = {0}-{1}, repository = {2}.",
                 svnWorkingCopyVersion.Start, svnWorkingCopyVersion.End, svnInfoEventArgs.Revision);
            }
            return (int)svnInfoEventArgs.Revision;
         }
         catch (Exception e)
         {
            _fLog.Error(0x3af242au, e);
            throw;
         }
      }
