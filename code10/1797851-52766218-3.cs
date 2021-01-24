    //Buffer for IO reading
    const Int32 BufferSize = 512;
    private void button2_Click(object sender, EventArgs e)
    {
        try
        {
            //Open the file and keep it open while there are lines with using
            using (var fileStream = File.OpenRead(fileName))
            {
                //Open the reader and keep it open while reading non null lines
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    String line;
                    //While the StreamReader is reading a line and it is not null, how to handle the line
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        //Split the string into an array
                        string[] splitarray = line.Split('-');
                        //Add the pieces of the array as a new row into the DataGridView
                        //This should be inside of a try/catch block or have some validation to make sure the array is a certain length (5 in this case)
                        dataGridView.Rows.Add(splitarray[0], splitarray[1], splitarray[2], splitarray[3], splitarray[4]);
                    }
                }
            }
        }
        catch(Exception ex){
            Console.WriteLine(ex.message)
        }
    }
