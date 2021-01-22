    /// <summary>
    /// Defines the "special characters"
    /// in Microsoft Word that VSTO 1.x
    /// translates into C# strings.
    /// </summary>
    internal struct Characters
    {
        /// <summary>
        /// Word Table end-of-cell marker.
        /// </summary>
        /// <remarks>
        /// Word Table end-of-row markers are also
        /// equal to this value.
        /// </remarks>
        internal static string CellBreak = "\r\a";
        /// <summary>
        /// Word line break (^l).
        /// </summary>
        internal static string LineBreak = "\v";
        /// <summary>
        /// Word Paragraph break (^p).
        /// </summary>
        internal static string ParagraphBreak = "\r";
    }
