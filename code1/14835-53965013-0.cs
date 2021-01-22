    //The guts of MailDefinition.CreateMailMessage
    //from https://github.com/Microsoft/referencesource/blob/master/System.Web/UI/WebControls/MailDefinition.cs
    
    if (replacements != null && !String.IsNullOrEmpty(body)) {
                        foreach (object key in replacements.Keys) {
                            string fromString = key as string;
    string toString = replacements[key] as string;
    
                            if ((fromString == null) || (toString == null)) {
                                throw new ArgumentException(SR.GetString(SR.MailDefinition_InvalidReplacements));
                            }
                            // DevDiv 151177
                            // According to http://msdn2.microsoft.com/en-us/library/ewy2t5e0.aspx, some special 
                            // constructs (starting with "$") are recognized in the replacement patterns. References of
                            // these constructs will be replaced with predefined strings in the final output. To use the 
                            // character "$" as is in the replacement patterns, we need to replace all references of single "$"
                            // with "$$", because "$$" in replacement patterns are replaced with a single "$" in the 
                            // final output. 
                            toString = toString.Replace("$", "$$");
                            body = Regex.Replace(body, fromString, toString, RegexOptions.IgnoreCase);
                        }
                    }
