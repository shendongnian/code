    private List<string> SplitLine(string line, string textQualifier, char delim, int colCount)
    {
        List<string> fields = new List<string>();
        string origLine = line;
        char textQual = '"';
        bool hasTextQual = false;
        if (!String.IsNullOrEmpty(textQualifier))
        {
            hasTextQual = true;
            textQual = textQualifier[0];            
        }
        if (hasTextQual)
        {
            while (!String.IsNullOrEmpty(line))
            {
                if (line[0] == textQual) // field is text qualified so look for next unqualified delimiter
                {
                    int fieldLen = 1;
                    while (true)
                    {
                        if (line.Length == 2) // must be final field (zero length)
                        {
                            fieldLen = 2;
                            break;
                        }
                        else if (fieldLen + 1 >= line.Length) // must be final field
                        {
                            fieldLen += 1;
                            break;
                        }
                        else if (line[fieldLen] == textQual && line[fieldLen + 1] == textQual) // escaped text qualifier
                        {
                            fieldLen += 2;
                        }
                        else if (line[fieldLen] == textQual && line[fieldLen + 1] == delim) // must be end of field
                        {
                            fieldLen += 1;
                            break;
                        }
                        else // not a delimiter
                        {
                            fieldLen += 1;
                        }
                    }
                    string escapedQual = textQual.ToString() + textQual.ToString();
                    fields.Add(line.Substring(1, fieldLen - 2).Replace(escapedQual, textQual.ToString())); // replace escaped qualifiers
                    if (line.Length >= fieldLen + 1)
                    {
                        line = line.Substring(fieldLen + 1);
                        if (line == "") // blank final field
                        {
                            fields.Add("");
                        }
                    }
                    else
                    {
                        line = "";
                    }
                }
                else // field is not text qualified
                {
                    int fieldLen = line.IndexOf(delim);
                    if (fieldLen != -1) // check next delimiter position
                    {
                        fields.Add(line.Substring(0, fieldLen));
                        line = line.Substring(fieldLen + 1);
                        if (line == "") // final field must be blank 
                        {
                            fields.Add("");
                        }
                    }
                    else // must be last field
                    {
                        fields.Add(line);
                        line = "";
                    }
                }
            }
        }
        else // if there is no text qualifier, then use existing split function
        {
            fields.AddRange(line.Split(delim));
        }      
        if (colCount > 0 && colCount != fields.Count) // count doesn't match expected so throw exception
        {
            throw new Exception("Field count was:" + fields.Count.ToString() + ", expected:" + colCount.ToString() + ". Line:" + origLine);
        }
        return fields;
    }
