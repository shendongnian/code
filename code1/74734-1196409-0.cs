    /// <summary>
    /// Reads and parses xdf strings
    /// </summary>
    public sealed class XdfReader {
        /// <summary>
        /// Instantiates a new instance of the DCOMProductions.BitFlex.IO.XdfReader class.
        /// </summary>
        public XdfReader() {
            //
            // TODO: Any constructor code here
            //
        }
        #region Constants
        /// <devdoc>
        /// This regular expression matches against a section beginning. A section may look like the following:
        /// 
        ///     SectionName:Begin
        ///     
        /// Where 'SectionName' is the name of the section, and ':Begin' represents that this is the
        /// opening tag for the section. This allows the parser to differentiate between open and
        /// close tags.
        /// </devdoc>
        private const String SectionBeginRegularExpression = @"[0-9a-zA-Z]*:Begin";
        /// <devdoc>
        /// This regular expression matches against a section ending. A section may look like the following:
        /// 
        ///     SectionName:End
        ///     
        /// Where 'SectionName' is the name of the section, and ':End' represents that this is the
        /// closing tag for the section. This allows the parser to differentiate between open and
        /// close tags.
        /// </devdoc>
        private const String SectionEndRegularExpression = @"[0-9a-zA-Z]*:End";
        /// <devdoc>
        /// This regular expression matches against a key and it's value. A key may look like the following:
        /// 
        ///     KeyName=KeyValue
        ///     KeyName = KeyValue
        ///     KeyName =KeyValue
        ///     KeyName= KeyValue
        ///     KeyName    =       KeyValue
        ///                 
        /// And so on so forth. This regular expression matches against all of these, where the whitespace
        /// former and latter of the assignment operator are optional.
        /// </devdoc>
        private const String KeyRegularExpression = @"[0-9a-zA-Z]*\s*?=\s*?[^\r]*";
        #endregion
        #region Methods
        public void Flush() {
            throw new System.NotImplementedException();
        }
        private String GetSectionName(String xdf) {
            Match sectionMatch = Regex.Match(xdf, SectionBeginRegularExpression);
            
            if (sectionMatch.Success) {
                String retVal = sectionMatch.Value;
                retVal = retVal.Substring(0, retVal.IndexOf(':'));
                return retVal;
            }
            else {
                throw new BitFlex.IO.XdfException("The specified xdf did not contain a valid section.");
            }
        }
        public XdfFile ReadFile(String fileName) {
            throw new System.NotImplementedException();
        }
        public XdfKey ReadKey(String xdf) {
            Match keyMatch = Regex.Match(xdf, KeyRegularExpression);
            if (keyMatch.Success) {
                String name = keyMatch.Value.Substring(0, keyMatch.Value.IndexOf('='));
                name = name.TrimEnd(' ');
                XdfKey retVal = new XdfKey(name);
                String value = keyMatch.Value.Remove(0, keyMatch.Value.IndexOf('=') + 1);
                value = value.TrimStart(' ');
                retVal.Value = value;
                return retVal;
            }
            else {
                throw new BitFlex.IO.XdfException("The specified xdf did not contain a valid key.");
            }
        }
        public XdfSection ReadSection(String xdf) {
            if (ValidateSection(xdf)) {
                String[] rows = xdf.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                XdfSection rootSection = new XdfSection(GetSectionName(rows[0])); System.Diagnostics.Debug.WriteLine(rootSection.Name);
                do {
                    Match beginMatch = Regex.Match(xdf, SectionBeginRegularExpression);
                    beginMatch = beginMatch.NextMatch();
                    if (beginMatch.Success) {
                        Match endMatch = Regex.Match(xdf, String.Format("{0}:End", GetSectionName(beginMatch.Value)));
                        if (endMatch.Success) {
                            String sectionXdf = xdf.Substring(beginMatch.Index, (endMatch.Index + endMatch.Length) - beginMatch.Index);
                            xdf = xdf.Remove(beginMatch.Index, (endMatch.Index + endMatch.Length) - beginMatch.Index);
                            XdfSection section = ReadSection(sectionXdf); System.Diagnostics.Debug.WriteLine(section.Name);
                            rootSection.Sections.Add(section);
                        }
                        else {
                            throw new BitFlex.IO.XdfException(String.Format("There is a missing section ending at index {0}.", endMatch.Index));
                        }
                    }
                    else {
                        break;
                    }
                } while (true);
                MatchCollection keyMatches = Regex.Matches(xdf, KeyRegularExpression);
                foreach (Match item in keyMatches) {
                    XdfKey key = ReadKey(item.Value);
                    rootSection.Keys.Add(key);
                }
                return rootSection;
            }
            else {
                throw new BitFlex.IO.XdfException("The specified xdf did not contain a valid section.");
            }
        }
        private Boolean ValidateSection(String xdf) {
            String[] rows = xdf.Split(new String[] { "\r\n" }, StringSplitOptions.None);
            if (Regex.Match(rows[0], SectionBeginRegularExpression).Success) {
                if (Regex.Match(rows[rows.Length - 1], SectionEndRegularExpression).Success) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }
        #endregion
    }
}
