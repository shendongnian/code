    //Buffer for IO reading
    const Int32 BufferSize = 512;
    private void button2_Click(object sender, EventArgs e)
    {
        //Open the file and keep it open while there are lines with using
        using (var fileStream = File.OpenRead(fileName))
        {
            //Open the reader and keep it open while reading non null lines
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] splitarray = line.Split('-');
                    dataGridView.Rows.Add(splitarray[0], splitarray[1], splitarray[2], splitarray[3], splitarray[4]);
                }
            }
        }
    }
