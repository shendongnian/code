    public static class FileNameExtensions
    {
        private static readonly Lazy<string[]> InvalidFileNameChars =
            new Lazy<string[]>(() => Path.GetInvalidPathChars()
                .Union(Path.GetInvalidFileNameChars()
                .Union(new[] { '+', '#' })).Select(c => c.ToString(CultureInfo.InvariantCulture)).ToArray());
        private static readonly HashSet<string> ProhibitedNames = new HashSet<string>
        {
            @"aux",
            @"con",
            @"clock$",
            @"nul",
            @"prn",
            @"com1",
            @"com2",
            @"com3",
            @"com4",
            @"com5",
            @"com6",
            @"com7",
            @"com8",
            @"com9",
            @"lpt1",
            @"lpt2",
            @"lpt3",
            @"lpt4",
            @"lpt5",
            @"lpt6",
            @"lpt7",
            @"lpt8",
            @"lpt9"
        };
        public static bool IsValidFileName(string fileName)
        {
            return !string.IsNullOrWhiteSpace(fileName)
                && fileName.All(o => !IsInvalidFileNameChar(o))
                && !IsProhibitedName(fileName);
        }
        public static bool IsProhibitedName(string fileName)
        {
            return ProhibitedNames.Contains(fileName.ToLower(CultureInfo.InvariantCulture));
        }
        private static string ReplaceInvalidFileNameSymbols([CanBeNull] this string value, string replacementValue)
        {
            if (value == null)
            {
                return null;
            }
            return InvalidFileNameChars.Value.Aggregate(new StringBuilder(value),
                (sb, currentChar) => sb.Replace(currentChar, replacementValue)).ToString();
        }
        public static bool IsInvalidFileNameChar(char value)
        {
            return InvalidFileNameChars.Value.Contains(value.ToString(CultureInfo.InvariantCulture));
        }
        public static string GetValidFileName([NotNull] this string value)
        {
            return GetValidFileName(value, @"_");
        }
        public static string GetValidFileName([NotNull] this string value, string replacementValue)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(@"value should be non empty", nameof(value));
            }
            if (IsProhibitedName(value))
            {
                return (string.IsNullOrWhiteSpace(replacementValue) ? @"_" : replacementValue) + value; 
            }
            return ReplaceInvalidFileNameSymbols(value, replacementValue);
        }
        public static string GetFileNameError(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return CommonResources.SelectReportNameError;
            }
            if (IsProhibitedName(fileName))
            {
                return CommonResources.FileNameIsProhibited;
            }
            var invalidChars = fileName.Where(IsInvalidFileNameChar).Distinct().ToArray();
            if(invalidChars.Length > 0)
            {
                return string.Format(CultureInfo.CurrentCulture,
                    invalidChars.Length == 1 ? CommonResources.InvalidCharacter : CommonResources.InvalidCharacters,
                    StringExtensions.JoinQuoted(@",", @"'", invalidChars.Select(c => c.ToString(CultureInfo.CurrentCulture))));
            }
            return string.Empty;
        }
    }
