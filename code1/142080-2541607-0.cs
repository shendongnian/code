    /// <summary>
    /// Get the first n characters of some html text
    /// </summary>
    private string truncateTo(string s, int howMany, string ellipsis) {
        // return entire string if it's more than n characters
        if (s.Length < howMany)
            return s;
        
        Stack<string> elements = new Stack<string>();
        StringBuilder sb = new StringBuilder();
        int trueCount = 0;
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '<') {
                StringBuilder elem = new StringBuilder();
                bool selfclosing = false;
                if (s[i + 1] == '/') {
                    elements.Pop(); // Take the previous element off the stack
                    while (s[i] != '>') {
                        i++;
                    }
                }
                else { // not a closing tag so get the element name
                    
                    while (i < s.Length && s[i] != '>') {
                        if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] >= 'A' && s[i] <= 'Z')) {
                            elem.Append(s[i]);
                        }
                        else if (s[i] == '/' || s[i] == ' ') {
                            // self closing tag or end of tag name. Find the end of tag
                            do {
                                if (s[i] == '/' && s[i + 1] == '>') {
                                    // at the end of self-closing tag. Don't store
                                    selfclosing = true;
                                }
                                i++;
                            } while (i < s.Length && s[i] != '>');
                        }
                        i++;
                    } // end while( != '>' )
                    if (!selfclosing)
                        elements.Push(elem.ToString());
                } 
            }
            else {
                trueCount++;
                if (trueCount > howMany) {
                    sb.Append(s.Substring(0, i - 1));
                    sb.Append(ellipsis);
                    while (elements.Count > 0) {
                        sb.AppendFormat("</{0}>", elements.Pop());
                    }
                }
            }
        }
        return sb.ToString();
    }
