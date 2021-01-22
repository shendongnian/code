            try
            {
                StringBuilder str1 = new StringBuilder(Text);
                StringBuilder str = new StringBuilder();
                char ch;
                int i, k, j;
                for (i = 0; i < str1.Length; ) // from 0 to length of unpackedtext
                {
                    ch = str1[i]; // get current char from str1
                    k = 0; //count the number of repeated characters
                    if (i == str1.Length - 1) // If this is the last character
                    {
                        str.Append(ch);
                        break; //exit the loop
                    }
                    if (str1[i + 1] == ch) //if current symbol is next
                    {
                        for (j = i; j < str1.Length; j++) //packing the characters
                        {
                            if (str1[j] == ch) //if current symbol is next
                            {
                                if (k == 9) break; //the maximum number of characters packed 9, 
                                //or there might be problems with unpacking is not packed numeric characters
                                k++;
                            }
                            else break;
                        }
                        i = j;
                    }
                    else if ("0123456789".Contains(ch)) //if this digit and it is not repeated, then it must be escaped,
                        //so when unpacking to understand that this is not the number of repeated characters
                    {
                        k = 1;
                        i++;
                    }
                    else i++;
                    if (k != 0)
                        str.AppendFormat("{0}{1}", k, ch); //forming packed string
                    else
                        str.Append(ch);
                }
                return str.ToString();
            }
            catch
            {
                return null;
            }
        }
        public string UnpackText()
        {
            try
            {
                StringBuilder str1 = new StringBuilder(Text);
                StringBuilder str = new StringBuilder();
                char ch;
                char symb = 'a';
                int s = 0;
                int i, j;
                for (i = 0; i < str1.Length; ) // from 0 to length of packedtext
                {
                    ch = str1[i]; // get current char from str1
                    s = 0;
                    if ("123456789".Contains(ch)) //if this digit
                    {
                        if (i == str1.Length - 1) // If this is the last character
                        {
                            symb = ch;
                            s = 1;
                            i++;
                        }
                        else
                        {
                            symb = str1[i + 1]; // get packed symbol
                            i += 2;
                            s = Convert.ToInt32(ch) - 48; //get the number of repetitions
                        }
                    }
                    else
                    {
                        s = 0;
                        i++;
                    }
                    if (s > 0)
                    {
                        for (j = 0; j < s; j++) // write the decompressed symbol
                            str.Append(symb);
                    }
                    else
                        str.Append(ch);
                }
              return  str.ToString();
            }
            catch
            {
                return null;
            }
        }
