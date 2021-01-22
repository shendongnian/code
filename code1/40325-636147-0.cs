        void TestCharlesParse()
        {
            string s = @"var1=asdfasdf&var2=contain""""quote&var3=""contain&delim""&var4=""contain""""both&""";
            string[] os = CharlesParse(s);
            for (int i = 0; i < os.Length; i++)
                System.Windows.Forms.MessageBox.Show(os[i]);
        }
        string[] CharlesParse(string inputString)
        {
            string[] escapedQuotes = { "\"\"" };
            string[] sep1 = inputString.Split(escapedQuotes, StringSplitOptions.None);
            bool quoted = false;
            ArrayList sep2 = new ArrayList();
            for (int i = 0; i < sep1.Length; i++)
            {
                string[] sep3 = ((string)sep1[i]).Split('"');
                for (int j = 0; j < sep3.Length; j++)
                {
                    if (!quoted)
                    {
                        string[] sep4 = sep3[j].Split('&');
                        for (int k = 0; k < sep4.Length; k++)
                        {
                            if (k == 0)
                            {
                                if (sep2.Count == 0)
                                {
                                    sep2.Add(sep4[k]);
                                }
                                else
                                {
                                    sep2[sep2.Count - 1] = ((string)sep2[sep2.Count - 1]) + sep4[k];
                                }
                            }
                            else
                            {
                                sep2.Add(sep4[k]);
                            }
                        }
                    }
                    else
                    {
                        sep2[sep2.Count - 1] = ((string)sep2[sep2.Count - 1]) + sep3[j];
                    }
                    if (j < (sep3.Length-1))
                        quoted = !quoted;
                }
                if (i < (sep1.Length - 1))
                    sep2[sep2.Count - 1] = ((string)sep2[sep2.Count - 1]) + "\"";
            }
            string[] ret = new string[sep2.Count];
            for (int l = 0; l < sep2.Count; l++)
                ret[l] = (string)sep2[l];
            return ret;
        }
