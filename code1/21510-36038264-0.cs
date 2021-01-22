    /// <summary>
    /// Determines the swap file location for a cluster.
    /// </summary>
    /// <remarks>This enum contains the original text based values for backwards compatibility with versions previous to "8.1".</remarks>
    public enum VMwareClusterSwapFileLocation
    {
        /// <summary>
        /// The swap file location is unknown.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// The swap file is stored in the virtual machine directory.
        /// </summary>
        VmDirectory = 1,
        /// <summary>
        /// The swap file is stored in the datastore specified by the host.
        /// </summary>
        HostLocal = 2,
        /// <summary>
        /// The swap file is stored in the virtual machine directory. This value is obsolete and used for backwards compatibility.
        /// </summary>
        [XmlElement("vmDirectory")]
        ObseleteVmDirectory = 3,
        /// <summary>
        /// The swap file is stored in the datastore specified by the host. This value is obsolete and used for backwards compatibility.
        /// </summary>
        [XmlElement("hostLocal")]
        ObseleteHostLocal = 4,
    }
