        protected string CleanInput(string input)
        {
            var imp = (input ?? "");
            var removeChars = new Char[] { (Char)65279 };
            imp = new String(imp.ToCharArray().Where(c => !removeChars.Contains(c)).ToArray());
            return imp;
        }
