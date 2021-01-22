        /// <summary>
        /// Converts a numeric value into a string that represents the number expressed as a size value in bytes, kilobytes, megabytes, gigabytes, terabytes, petabytes or exabytes, depending on the size
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns>
        /// The number converted.
        /// </returns>
        public static string FormatFileSize(long size)
        {
            return FormatFileSize(size, null, null, null);
        }
        /// <summary>
        /// Converts a numeric value into a string that represents the number expressed as a size value in bytes, kilobytes, megabytes, gigabytes, terabytes, petabytes or exabytes, depending on the size
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="byteName">The string used for the byte name. If null is passed, "B" will be used.</param>
        /// <param name="numberFormat">The number format. If null is passed, "N2" will be used.</param>
        /// <param name="formatProvider">The format provider. May be null to use current culture.</param>
        /// <returns>The number converted.</returns>
        public static string FormatFileSize(long size, string byteName, string numberFormat, IFormatProvider formatProvider)
        {
            if (size < 0)
                throw new ArgumentException(null, "size");
            if (byteName == null)
            {
                byteName = "B";
            }
            if (string.IsNullOrEmpty(numberFormat))
            {
                numberFormat = "N2";
            }
            const decimal K = 1024;
            const decimal M = K * K;
            const decimal G = M * K;
            const decimal T = G * K;
            const decimal P = T * K;
            const decimal E = P * K;
            decimal dsize = size;
            string suffix = null;
            if (dsize >= E)
            {
                dsize /= E;
                suffix = "E";
            }
            else if (dsize >= P)
            {
                dsize /= P;
                suffix = "P";
            }
            else if (dsize >= T)
            {
                dsize /= T;
                suffix = "T";
            }
            else if (dsize >= G)
            {
                dsize /= G;
                suffix = "G";
            }
            else if (dsize >= M)
            {
                dsize /= M;
                suffix = "M";
            }
            else if (dsize >= K)
            {
                dsize /= K;
                suffix = "k";
            }
            if (suffix != null)
            {
                suffix = " " + suffix;
            }
            return string.Format(formatProvider, "{0:" + numberFormat + "}" + suffix + byteName, dsize);
        }
