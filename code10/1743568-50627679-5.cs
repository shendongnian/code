    public void Write(List<string[,]> arrays, string filepath)
    {
        using (StreamWriter sw = new StreamWriter(filepath))
        {
            foreach(string[,] array in arrays)
            {
                sw.WriteLine(array.GetLength(0) + " " + array.GetLength(1)); // write dimensions
                int i = 0;
                while(i < array.GetLength(0))
                {
                    string line = "";
                    int o = 0;
                    while(o < array.GetLength(1))
                    {
                        line = line + array[i, o];
                        if(o+1 < array.GetLength(1))
                        {
                            line = line + " ";
                        }
                        o++;
                    }
                    sw.WriteLine(line);
                    i++;
                }
                sw.WriteLine("#");
            }
        }
    }
