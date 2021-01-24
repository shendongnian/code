    var line = File.ReadAllLines("D:\\Sample.txt");
                using (TextWriter txt = new StreamWriter("D:\\Demo.txt"))
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        var fields = line[i].Remove(30);
                        //MessageBox.Show(fields.ToString());
                        txt.Write(line[i]);
    
                    }
    
                    txt.Close();
                }
