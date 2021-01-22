    private void WriteAndAppend()
    {
                string Path = Application.StartupPath + "\\notes.txt";
                FileInfo fi = new FileInfo(Path);
                StreamWriter SW;
                StreamReader SR;
                if (fi.Exists)
                {
                    SR = new StreamReader(Path);
                    string Line = "";
                    while (!SR.EndOfStream) // Till the last line
                    {
                        Line = SR.ReadLine();
                    }
                    SR.Close();
                    int x = 0;
                    if (Line.Trim().Length <= 0)
                    {
                        x = 0;
                    }
                    else
                    {
                        x = Convert.ToInt32(Line.Substring(0, Line.IndexOf('.')));
                    }
                    x++;
                    SW = new StreamWriter(Path, true);
                    SW.WriteLine("-----"+string.Format("{0:dd-MMM-yyyy hh:mm:ss tt}", DateTime.Now));
                    SW.WriteLine(x.ToString() + "." + textBox1.Text);
                    
                }
                else
                {
                    SW = new StreamWriter(Path);
                    SW.WriteLine("-----" + string.Format("{0:dd-MMM-yyyy hh:mm:ss tt}", DateTime.Now));
                    SW.WriteLine("1." + textBox1.Text);
                }
                SW.Flush();
                SW.Close();
            }
