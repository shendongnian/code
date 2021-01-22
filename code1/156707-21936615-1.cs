    using System.Runtime.InteropServices;
	
    private long WrapToClusterSize(long originalSize)
        {
            return ((originalSize + _clusterSize - 1) / _clusterSize) * _clusterSize;
        }
    
    private static int GetClusterSize(string rootPath)
        {
            int sectorsPerCluster = 0, bytesPerSector = 0, numFreeClusters = 0, totalNumClusters = 0;
            if (!GetDiskFreeSpace(rootPath, ref sectorsPerCluster, ref bytesPerSector, ref numFreeClusters,
                                  ref totalNumClusters))
            {
                // Satisfies rule CallGetLastErrorImmediatelyAfterPInvoke.
                // see http://msdn.microsoft.com/en-us/library/ms182199(v=vs.80).aspx
                var lastError = Marshal.GetLastWin32Error();
                throw new Exception(string.Format("Error code {0}", lastError));
            }
            return sectorsPerCluster * bytesPerSector;
        }
	[DllImport(Kernel32DllImport, SetLastError = true)]
        private static extern bool GetDiskFreeSpace(
            string rootPath,
            ref int sectorsPerCluster,
            ref int bytesPerSector,
            ref int numFreeClusters,
            ref int totalNumClusters);
