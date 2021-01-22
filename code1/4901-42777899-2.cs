    public class ValidFileNameAttribute : ValidationAttribute
    {
        public ValidFileNameAttribute()
        {
            RequireExtension = true;
            ErrorMessage = "Invalid Filename";
        }
        private const int _maxLength = 255;
        public override bool IsValid(object value)
        {
            var fileName = (string)value;
            if (string.IsNullOrEmpty(fileName)) { return true;  }
            if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) > -1 ||
                (!AllowHidden && fileName[0] == '.') ||
                fileName[fileName.Length - 1]== '.' ||
                fileName.Length > _maxLength)
            {
                return false;
            }
            string extension = Path.GetExtension(fileName);
            return (!RequireExtension || extension != string.Empty)
                && (ExtensionList==null || ExtensionList.Contains(extension));
        }
        private const string sepChar = ",";
        private IEnumerable<string> ExtensionList { get; set; }
        public bool AllowHidden { get; set; }
        public bool RequireExtension { get; set; }
        public string AllowedExtensions {
            get { return string.Join(sepChar, ExtensionList); } 
            set {
                if (string.IsNullOrEmpty(value))
                { ExtensionList = null; }
                else {
                    ExtensionList = value.Split(new char[] { sepChar[0] })
                        .Select(s => s[0] == '.' ? s : ('.' + s))
                        .ToList();
                }
        } }
        public override bool RequiresValidationContext => false;
    }
