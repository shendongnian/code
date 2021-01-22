    #region StorageDifferential
    /// <summary>
    /// Converts between Base 2 or Base 10 storage units [TB, GB, MB, KB, Bytes]
    /// </summary>
    public enum Differential : int
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
    /// <summary>
    /// Enumeration of recognized storage sizes [in Bytes]
    /// </summary>
    public enum StorageSizes : long
    {
        /// <summary>
        /// Base 10 Conversion
        /// </summary>
        KILOBYTE = 1000,
        MEGABYTE = 1000000,
        GIGABYTE = 1000000000,
        TERABYTE = 1000000000000,
        /// <summary>
        /// Base 2 Conversion
        /// </summary>
        KIBIBYTE = 1024,
        MEBIBYTE = 1048576,
        GIBIBYTE = 1073741824,
        TEBIBYTE = 1099511627776,
    }
    #endregion
    #region StorageBase
    /// <summary>
    /// Storage powers 10 based or 1024 based
    /// </summary>
    public enum StorageBase : int
    {
        /// <summary>
        /// 1024 Base power, Typically used in memory measurements
        /// </summary>
        BASE2,
        /// <summary>
        /// 10 Base power, Used in storage mediums like harddrives
        /// </summary>
        BASE10,
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
        /// <param name="SizeDifferential">Storage conversion differential [enum]</param>
        /// <param name="UnitSize">Size as mutiple of unit type units [double]</param>
        /// <param name="BaseUnit">Size of the base power [enum]</param>
        /// <returns>Converted unit size [double]</returns>
        public static double Convert(Differential SizeDifferential, double UnitSize, StorageBase BaseUnit = StorageBase.BASE10)
        {
            if (UnitSize < 0.000000000001) return 0;
            double POWER1 = 1000;
            double POWER2 = 1000000;
            double POWER3 = 1000000000;
            double POWER4 = 1000000000000;
            if (BaseUnit == StorageBase.BASE2)
            {
                POWER1 = 1024;
                POWER2 = 1048576;
                POWER3 = 1073741824;
                POWER4 = 1099511627776;
            }
            switch (SizeDifferential)
            {
                case Differential.ByteToKilo:
                    return UnitSize / POWER1;
                case Differential.ByteToMega:
                    return UnitSize / POWER2;
                case Differential.ByteToGiga:
                    return UnitSize / POWER3;
                case Differential.ByteToTera:
                    return UnitSize / POWER4;
                case Differential.KiloToByte:
                    return UnitSize * POWER1;
                case Differential.KiloToMega:
                    return UnitSize / POWER1;
                case Differential.KiloToGiga:
                    return UnitSize / POWER2;
                case Differential.KiloToTera:
                    return UnitSize / POWER3;
                case Differential.MegaToByte:
                    return UnitSize * POWER2;
                case Differential.MegaToKilo:
                    return UnitSize * POWER1;
                case Differential.MegaToGiga:
                    return UnitSize / POWER1;
                case Differential.MegaToTera:
                    return UnitSize / POWER2;
                case Differential.GigaToByte:
                    return UnitSize * POWER3;
                case Differential.GigaToKilo:
                    return UnitSize * POWER2;
                case Differential.GigaToMega:
                    return UnitSize * POWER1;
                case Differential.GigaToTerra:
                    return UnitSize / POWER1;
                case Differential.TeraToByte:
                    return UnitSize * POWER4;
                case Differential.TeraToKilo:
                    return UnitSize * POWER3;
                case Differential.TeraToMega:
                    return UnitSize * POWER2;
                case Differential.TeraToGiga:
                    return UnitSize * POWER1;
            }
            return 0;
        }
    }
