    #region StorageDifferential
    /// <summary>
    /// Converts between Base 2 storage units [TB, GB, MB, KB, Bytes]
    /// </summary>
    public enum StorageDifferential : int
    {
        /// <summary>
        /// Convert Bytes to Kilobytes
        /// </summary>
        ByteToKilo,
        /// <summary>
        /// Convert Bytes to Megabytes
        /// </summary>
        ByteToMega,
        /// <summary>
        /// Convert Bytes to Gigabytes
        /// </summary>
        ByteToGiga,
        /// <summary>
        /// Convert Bytes to Teraytes
        /// </summary>
        ByteToTera,
        /// <summary>
        /// Convert Kilobytes to Bytes
        /// </summary>
        KiloToByte,
        /// <summary>
        /// Convert Kilobytes to Megabytes
        /// </summary>
        KiloToMega,
        /// <summary>
        /// Convert Kilobytes to Gigabytes
        /// </summary>
        KiloToGiga,
        /// <summary>
        /// Convert Kilobytes to Terabytes
        /// </summary>
        KiloToTera,
        /// <summary>
        /// Convert Megabytes to Bytes
        /// </summary>
        MegaToByte,
        /// <summary>
        /// Convert Megabytes to Kilobytes
        /// </summary>
        MegaToKilo,
        /// <summary>
        /// Convert Megabytes to Gigabytes
        /// </summary>
        MegaToGiga,
        /// <summary>
        /// Convert Megabytes to Terabytes
        /// </summary>
        MegaToTera,
        /// <summary>
        /// Convert Gigabytes to Bytes
        /// </summary>
        GigaToByte,
        /// <summary>
        /// Convert Gigabytes to Kilobytes
        /// </summary>
        GigaToKilo,
        /// <summary>
        /// Convert Gigabytes to Megabytes
        /// </summary>
        GigaToMega,
        /// <summary>
        /// Convert Gigabytes to Terabytes
        /// </summary>
        GigaToTerra,
        /// <summary>
        /// Convert Terabyte to Bytes
        /// </summary>
        TeraToByte,
        /// <summary>
        /// Convert Terabyte to Kilobytes
        /// </summary>
        TeraToKilo,
        /// <summary>
        /// Convert Terabytes to Megabytes
        /// </summary>
        TeraToMega,
        /// <summary>
        /// Convert Terabytes to Gigabytes
        /// </summary>
        TeraToGiga,
    }
    #endregion
    #region Storage Sizes
    public enum StorageSizes : long
    {
        KILOBYTE = 1024,
        MEGABYTE = 1048576,
        GIGABYTE = 1073741824,
        TERABYTE = 1099511627776,
    }
    #endregion
    /// <summary>
    /// Convert between base 1024 storage units [TB, GB, MB, KB, Byte]
    /// </summary>
    public static class StorageConverter
    {
        /// <summary>
        /// Convert between base 1024 storage units [TB, GB, MB, KB, Byte]
        /// </summary>
        /// <param name="Differential">Storage conversion differential [enum]</param>
        /// <param name="UnitSize">Size as mutiple of unit type units [double]</param>
        /// <returns>Converted unit size [double]</returns>
        public static double Convert(StorageDifferential Differential, double UnitSize)
        {
            if (UnitSize < 0.00000001) return 0;
            const double BASE1 = 1024;
            const double BASE2 = 1048576;
            const double BASE3 = 1073741824;
            const double BASE4 = 1099511627776;
            switch (Differential)
            {
                case StorageDifferential.ByteToKilo:
                    return UnitSize / BASE1;
                case StorageDifferential.ByteToMega:
                    return UnitSize / BASE2;
                case StorageDifferential.ByteToGiga:
                    return UnitSize / BASE3;
                case StorageDifferential.ByteToTera:
                    return UnitSize / BASE4;
                case StorageDifferential.KiloToByte:
                    return UnitSize * BASE1;
                case StorageDifferential.KiloToMega:
                    return UnitSize / BASE1;
                case StorageDifferential.KiloToGiga:
                    return UnitSize / BASE2;
                case StorageDifferential.KiloToTera:
                    return UnitSize / BASE3;
                case StorageDifferential.MegaToByte:
                    return UnitSize * BASE2;
                case StorageDifferential.MegaToKilo:
                    return UnitSize * BASE1;
                case StorageDifferential.MegaToGiga:
                    return UnitSize / BASE1;
                case StorageDifferential.MegaToTera:
                    return UnitSize / BASE2;
                case StorageDifferential.GigaToByte:
                    return UnitSize * BASE3;
                case StorageDifferential.GigaToKilo:
                    return UnitSize * BASE2;
                case StorageDifferential.GigaToMega:
                    return UnitSize * BASE1;
                case StorageDifferential.GigaToTerra:
                    return UnitSize / BASE1;
                case StorageDifferential.TeraToByte:
                    return UnitSize * BASE4;
                case StorageDifferential.TeraToKilo:
                    return UnitSize * BASE3;
                case StorageDifferential.TeraToMega:
                    return UnitSize * BASE2;
                case StorageDifferential.TeraToGiga:
                    return UnitSize * BASE1;
            }
            return 0;
        }
    }
