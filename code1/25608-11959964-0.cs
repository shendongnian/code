    /*
         * This method takes in JSON in the form returned by javascript's
         * JSON.stringify(Object) and returns a string->string dictionary.
         * This method may be of use when the format of the json is unknown.
         * You can modify the delimiters, etc pretty easily in the source
         * (sorry I didn't abstract it--I have a very specific use).
         */ 
        public static Dictionary<string, string> jsonParse(string rawjson)
        {
            Dictionary<string, string> outdict = new Dictionary<string, string>();
            StringBuilder keybufferbuilder = new StringBuilder();
            StringBuilder valuebufferbuilder = new StringBuilder();
            StringReader bufferreader = new StringReader(rawjson);
            int s = 0;
            bool reading = false;
            bool inside_string = false;
            bool reading_value = false;
            //break at end (returns -1)
            while (s >= 0)
            {
                s = bufferreader.Read();
                //opening of json
                if (!reading)
                {
                    if ((char)s == '{' && !inside_string && !reading) reading = true;
                    continue;
                }
                else
                {
                    //if we find a quote and we are not yet inside a string, advance and get inside
                    if (!inside_string)
                    {
                        //read past the quote
                        if ((char)s == '\"') inside_string = true;
                        continue;
                    }
                    if (inside_string)
                    {
                        //if we reached the end of the string
                        if ((char)s == '\"')
                        {
                            inside_string = false;
                            s = bufferreader.Read(); //advance pointer
                            if ((char)s == ':')
                            {
                                reading_value = true;
                                continue;
                            }
                            if (reading_value && (char)s == ',')
                            {
                                //we know we just ended the line, so put itin our dictionary
                                if (!outdict.ContainsKey(keybufferbuilder.ToString())) outdict.Add(keybufferbuilder.ToString(), valuebufferbuilder.ToString());
                                //and clear the buffers
                                keybufferbuilder.Clear();
                                valuebufferbuilder.Clear();
                                reading_value = false;
                            }
                            if (reading_value && (char)s == '}')
                            {
                                //we know we just ended the line, so put itin our dictionary
                                if (!outdict.ContainsKey(keybufferbuilder.ToString())) outdict.Add(keybufferbuilder.ToString(), valuebufferbuilder.ToString());
                                //and clear the buffers
                                keybufferbuilder.Clear();
                                valuebufferbuilder.Clear();
                                reading_value = false;
                                reading = false;
                                break;
                            }
                        }
                        else
                        {
                            if (reading_value)
                            {
                                valuebufferbuilder.Append((char)s);
                                continue;
                            }
                            else
                            {
                                keybufferbuilder.Append((char)s);
                                continue;
                            }
                        }
                    }
                    else
                    {
                        switch ((char)s)
                        {
                            case ':':
                                reading_value = true;
                                break;
                            default:
                                if (reading_value)
                                {
                                    valuebufferbuilder.Append((char)s);
                                }
                                else
                                {
                                    keybufferbuilder.Append((char)s);
                                }
                                break;
                        }
                    }
                }
            }
            return outdict;
        }
