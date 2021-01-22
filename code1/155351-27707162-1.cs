 csharp
public StreamWriter(string path, bool append);
 while opening the file
 csharp
string path="C:\\MyFolder\\Notes.txt"
StreamWriter writer = new StreamWriter(path, true);
 
First parameter is a string to hold a full file path
Second parameter is Append Mode, that in this case is made true
Writing to the file can be done with:
writer.Write(string)
 or 
writer.WriteLine(string)
**Sample Code**
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
