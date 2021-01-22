    public static string AddCssClass(string classContainer, string className)
        {
            if (string.IsNullOrEmpty(classContainer)) return className ?? string.Empty;
            if (string.IsNullOrEmpty(className)) return classContainer;
                
            var classNames = classContainer.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (Array.Exists(classNames, delegate(string s) { return s.Equals(className); })) return classContainer;
            return classContainer + " " + className;
        }
        public static string RemoveCssClass(string classContainer, string className)
        {
            if (string.IsNullOrEmpty(classContainer)) return className ?? string.Empty;
            if (string.IsNullOrEmpty(className)) return classContainer;
            var classNames = classContainer.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int index = Array.FindIndex(classNames, delegate(string s) { return s.Equals(className); });
            if (index >= 0)
            {
                return string.Join(" ", classNames, 0, index) +
                    (   index + 1 < classNames.Length ?
                        " " + string.Join(" ", classNames, index + 1, classNames.Length - index - 1)
                        :
                        string.Empty    );
            }
            return classContainer;
        }
        public static string ToggleCssClass(string classContainer, string className)
        {
            if (string.IsNullOrEmpty(classContainer)) return className ?? string.Empty;
            if (string.IsNullOrEmpty(className)) return classContainer;
            var classNames = classContainer.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (Array.Exists(classNames, delegate(string s) { return s.Equals(className); })) return RemoveCssClass(classContainer, className);
            return classContainer + " " + className;
        }
