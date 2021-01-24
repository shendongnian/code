     foreach (string x in lst)
                {
                    int position = x.IndexOf("Marken>");
                    string text = "";
                    if (position > -1)
                    {
                        text = x.Substring(position + 7);
                        break;
                    }
                }
