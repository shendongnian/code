    public string check()
        {
            ArrayList tags = getTags();
            
            
            int stackSize = tags.Count;
            
            Stack stack = new Stack(stackSize);
            foreach (string tag in tags)
            {
                if (!tag.Contains('/'))
                {
                    stack.push(tag);
                }
                else
                {
                    if (!stack.isEmpty())
                    {
                        string startTag = stack.pop();
                        startTag = startTag.Substring(1, startTag.Length - 1);
                        string endTag = tag.Substring(2, tag.Length - 2);
                        if (!startTag.Equals(endTag))
                        {
                            return "Fout: geen matchende eindtag";
                        }
                    }
                    else
                    {
                        return "Fout: geen matchende openeningstag";
                    }
                }
            }
            
            if (!stack.isEmpty())
            {
                return "Fout: geen matchende eindtag";
            }            
            return "Xml is valid";
        }
