    public void Save(StreamWriter stream, char delim = ',')
    {
        if(_cols > 4) 
        {
        for (int row = 0; row < _rows; row++)
        {
            for (int col = 4; col < _cols; col++)
            {
                if(col != 10)
                {
                    stream.Write(this[col, row]);
                    if (col < _cols - 1)
                    {
                        stream.Write(delim);
                    }
                }
            }
            stream.WriteLine();
        }
        }
        stream.Flush();
        stream.Close();
    }
