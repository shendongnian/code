    myarr = new mytable[50];
            number_of_records = 0;
            number_of_records = fulllines.Length;
            for (int line = 1; line < fulllines.Length; line++)
            {
                int c = 0;
                for (int i = 0; i < record_lenth; i++)
                {
                    string data = "";
                    string currentline = fulllines[line];
                    string value = "";
                    for (int x = c; x < fulllines[line].Length; x++)
                    {
                        value += currentline[x];
                    }
                    foreach (var item in value)
                    {
                        if (item == ',' || item == ';')
                        {
                            c++;
                            break;
                        }
                        else
                        {
                            data += item;
                            c++;
                        }
                    }
                }
            }
