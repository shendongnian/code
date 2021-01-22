        /// <summary>
        /// Converts a numeric value into a string that represents the number expressed as a size value in bytes,
        /// kilobytes, megabytes, or gigabytes, depending on the size.
        /// </summary>
        /// <param name="fileSize">The numeric value to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string FormatByteSize(double fileSize)
        {
            FileSizeUnit unit = FileSizeUnit.B;
            while (fileSize >= 1024 && unit < FileSizeUnit.YB)
            {
                fileSize = fileSize / 1024;
                unit++;
            }
            return string.Format("{0:0.##} {1}", fileSize, unit);
        }
        /// <summary>
        /// Converts a numeric value into a string that represents the number expressed as a size value in bytes,
        /// kilobytes, megabytes, or gigabytes, depending on the size.
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns>The converted string.</returns>
        public static string FormatByteSize(FileInfo fileInfo)
        {
            return FormatByteSize(fileInfo.Length);
        }
    }
    public enum FileSizeUnit : byte
    {
        B,
        KB,
        MB,
        GB,
        TB,
        PB,
        EB,
        ZB,
        YB
    }
