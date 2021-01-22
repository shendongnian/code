                string[] data = null;
                using (StreamReader sr = new StreamReader("data.txt"))
                {
                    data = sr.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                }
                if (data != null && data.Length > 0)
                {
                    int colIndex1 = -1;
                    int colIndex2 = -1;
                    string[] line = data[0].Split(new char[] { '|' });
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (String.Compare(line[i], comboBox1.Text, true) == 0)
                        {
                            colIndex1 = i;
                        }
                        if (String.Compare(line[i], comboBox2.Text, true) == 0)
                        {
                            colIndex2 = i;
                        }
                    }
                    using (StreamWriter sw = new StreamWriter("output.txt"))
                    {
                        sw.WriteLine(comboBox1.Text + "|" + comboBox2.Text);
                        for (int i = 1; i < data.Length; i++)
                        {
                            line = data[i].Split(new char[] { '|' });
                            sw.WriteLine(line[colIndex1] + "|" + line[colIndex2]);
                        }
                    }
                }
