    public class ValidFileNameAttribute : ValidationAttribute
    {
        public ValidFileNameAttribute()
        {
            RequireExtension = true;
            ErrorMessage = "{0} is an Invalid Filename";
            MaxLength = 255; //superseeded in modern windows environments
        }
        public override bool IsValid(object value)
        {
            //http://stackoverflow.com/questions/422090/in-c-sharp-check-that-filename-is-possibly-valid-not-that-it-exists
            var fileName = (string)value;
            if (string.IsNullOrEmpty(fileName)) { return true;  }
            if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) > -1 ||
                (!AllowHidden && fileName[0] == '.') ||
                fileName[fileName.Length - 1]== '.' ||
                fileName.Length > MaxLength)
            {
                return false;
            }
            string extension = Path.GetExtension(fileName);
            return (!RequireExtension || extension != string.Empty)
                && (ExtensionList==null || ExtensionList.Contains(extension));
        }
        private const string _sepChar = ",";
        private IEnumerable<string> ExtensionList { get; set; }
        public bool AllowHidden { get; set; }
        public bool RequireExtension { get; set; }
        public int MaxLength { get; set; }
        public string AllowedExtensions {
            get { return string.Join(_sepChar, ExtensionList); } 
            set {
                if (string.IsNullOrEmpty(value))
                { ExtensionList = null; }
                else {
                    ExtensionList = value.Split(new char[] { _sepChar[0] })
                        .Select(s => s[0] == '.' ? s : ('.' + s))
                        .ToList();
                }
        } }
        public override bool RequiresValidationContext => false;
    }
