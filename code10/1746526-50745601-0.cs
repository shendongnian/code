                string str = "Ł9CZIA KUOTA PIV 1,21 SUMA 12,36 otóuka 2 | 0350 |tKasa 1";
                int index = str.IndexOf("SUMA");
                if (index > -1)
                {
                    str = str.Substring(index + 5);// SUMA + SPACE char == 4+1 = 5
                    int inx = str.IndexOf(" ");
                    if (index > -1)
                    {
                        str = str.Substring(0, inx);
                        Console.WriteLine(str.Trim());
                    }
                }
