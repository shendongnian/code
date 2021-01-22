    /// <summary>
    /// Defines a set of utilities for creating slug urls.
    /// </summary>
    public static class Slug
    {
        /// <summary>
        /// Creates a slug from the specified text.
        /// </summary>
        /// <param name="text">The text. If null if specified, null will be returned.</param>
        /// <returns>
        /// A slugged text.
        /// </returns>
        public static string Create(string text)
        {
            return Create(text, (SlugOptions)null);
        }
    
        /// <summary>
        /// Creates a slug from the specified text.
        /// </summary>
        /// <param name="text">The text. If null if specified, null will be returned.</param>
        /// <param name="options">The options. May be null.</param>
        /// <returns>A slugged text.</returns>
        public static string Create(string text, SlugOptions options)
        {
            if (text == null)
                return null;
    
            if (options == null)
            {
                options = new SlugOptions();
            }
    
            string normalised;
            if (options.EarlyTruncate && options.MaximumLength > 0 && text.Length > options.MaximumLength)
            {
                normalised = text.Substring(0, options.MaximumLength).Normalize(NormalizationForm.FormD);
            }
            else
            {
                normalised = text.Normalize(NormalizationForm.FormD);
            }
            int max = options.MaximumLength > 0 ? Math.Min(normalised.Length, options.MaximumLength) : normalised.Length;
            StringBuilder sb = new StringBuilder(max);
            for (int i = 0; i < normalised.Length; i++)
            {
                char c = normalised[i];
                UnicodeCategory uc = char.GetUnicodeCategory(c);
                if (options.AllowedUnicodeCategories.Contains(uc) && options.IsAllowed(c))
                {
                    switch (uc)
                    {
                        case UnicodeCategory.UppercaseLetter:
                            if (options.ToLower)
                            {
                                c = options.Culture != null ? char.ToLower(c, options.Culture) : char.ToLowerInvariant(c);
                            }
                            sb.Append(options.Replace(c));
                            break;
    
                        case UnicodeCategory.LowercaseLetter:
                            if (options.ToUpper)
                            {
                                c = options.Culture != null ? char.ToUpper(c, options.Culture) : char.ToUpperInvariant(c);
                            }
                            sb.Append(options.Replace(c));
                            break;
    
                        default:
                            sb.Append(options.Replace(c));
                            break;
                    }
                }
                else if (uc == UnicodeCategory.NonSpacingMark)
                {
                    // don't add a separator
                }
                else
                {
                    if (options.Separator != null && !EndsWith(sb, options.Separator))
                    {
                        sb.Append(options.Separator);
                    }
                }
    
                if (options.MaximumLength > 0 && sb.Length >= options.MaximumLength)
                    break;
            }
    
            string result = sb.ToString();
    
            if (options.MaximumLength > 0 && result.Length > options.MaximumLength)
            {
                result = result.Substring(0, options.MaximumLength);
            }
    
            if (!options.CanEndWithSeparator && options.Separator != null && result.EndsWith(options.Separator))
            {
                result = result.Substring(0, result.Length - options.Separator.Length);
            }
    
            return result.Normalize(NormalizationForm.FormC);
        }
    
        private static bool EndsWith(StringBuilder sb, string text)
        {
            if (sb.Length < text.Length)
                return false;
    
            for (int i = 0; i < text.Length; i++)
            {
                if (sb[sb.Length - 1 - i] != text[text.Length - 1 - i])
                    return false;
            }
            return true;
        }
    }
    
    /// <summary>
    /// Defines options for the Slug utility class.
    /// </summary>
    public class SlugOptions
    {
        /// <summary>
        /// Defines the default maximum length. Currently equal to 80.
        /// </summary>
        public const int DefaultMaximumLength = 80;
    
        /// <summary>
        /// Defines the default separator. Currently equal to "-".
        /// </summary>
        public const string DefaultSeparator = "-";
    
        private bool _toLower;
        private bool _toUpper;
    
        /// <summary>
        /// Initializes a new instance of the <see cref="SlugOptions"/> class.
        /// </summary>
        public SlugOptions()
        {
            MaximumLength = DefaultMaximumLength;
            Separator = DefaultSeparator;
            AllowedUnicodeCategories = new List<UnicodeCategory>();
            AllowedUnicodeCategories.Add(UnicodeCategory.UppercaseLetter);
            AllowedUnicodeCategories.Add(UnicodeCategory.LowercaseLetter);
            AllowedUnicodeCategories.Add(UnicodeCategory.DecimalDigitNumber);
            AllowedRanges = new List<KeyValuePair<short, short>>();
            AllowedRanges.Add(new KeyValuePair<short, short>((short)'a', (short)'z'));
            AllowedRanges.Add(new KeyValuePair<short, short>((short)'A', (short)'Z'));
            AllowedRanges.Add(new KeyValuePair<short, short>((short)'0', (short)'9'));
        }
    
        /// <summary>
        /// Gets the allowed unicode categories list.
        /// </summary>
        /// <value>
        /// The allowed unicode categories list.
        /// </value>
        public virtual IList<UnicodeCategory> AllowedUnicodeCategories { get; private set; }
    
        /// <summary>
        /// Gets the allowed ranges list.
        /// </summary>
        /// <value>
        /// The allowed ranges list.
        /// </value>
        public virtual IList<KeyValuePair<short, short>> AllowedRanges { get; private set; }
    
        /// <summary>
        /// Gets or sets the maximum length.
        /// </summary>
        /// <value>
        /// The maximum length.
        /// </value>
        public virtual int MaximumLength { get; set; }
    
        /// <summary>
        /// Gets or sets the separator.
        /// </summary>
        /// <value>
        /// The separator.
        /// </value>
        public virtual string Separator { get; set; }
    
        /// <summary>
        /// Gets or sets the culture for case conversion.
        /// </summary>
        /// <value>
        /// The culture.
        /// </value>
        public virtual CultureInfo Culture { get; set; }
    
        /// <summary>
        /// Gets or sets a value indicating whether the string can end with a separator string.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the string can end with a separator string; otherwise, <c>false</c>.
        /// </value>
        public virtual bool CanEndWithSeparator { get; set; }
    
        /// <summary>
        /// Gets or sets a value indicating whether the string is truncated before normalization.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the string is truncated before normalization; otherwise, <c>false</c>.
        /// </value>
        public virtual bool EarlyTruncate { get; set; }
    
        /// <summary>
        /// Gets or sets a value indicating whether to lowercase the resulting string.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the resulting string must be lowercased; otherwise, <c>false</c>.
        /// </value>
        public virtual bool ToLower
        {
            get
            {
                return _toLower;
            }
            set
            {
                _toLower = value;
                if (_toLower)
                {
                    _toUpper = false;
                }
            }
        }
    
        /// <summary>
        /// Gets or sets a value indicating whether to uppercase the resulting string.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the resulting string must be uppercased; otherwise, <c>false</c>.
        /// </value>
        public virtual bool ToUpper
        {
            get
            {
                return _toUpper;
            }
            set
            {
                _toUpper = value;
                if (_toUpper)
                {
                    _toLower = false;
                }
            }
        }
    
        /// <summary>
        /// Determines whether the specified character is allowed.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns>true if the character is allowed; false otherwise.</returns>
        public virtual bool IsAllowed(char character)
        {
            foreach (var p in AllowedRanges)
            {
                if (character >= p.Key && character <= p.Value)
                    return true;
            }
            return false;
        }
    
        /// <summary>
        /// Replaces the specified character by a given string.
        /// </summary>
        /// <param name="character">The character to replace.</param>
        /// <returns>a string.</returns>
        public virtual string Replace(char character)
        {
            return character.ToString();
        }
    }
