    string dataRow = "";
    
    try
    {
        TextReader tr = new StreamReader("filename.txt");
    
        while (true)
        {
            dataRow = tr.ReadLine();
            if (dataRow.Substring(1, 8) != "SECTION_")
                break;
            else
                //Parse line for section code and line number and log values
                continue;
        }
        tr.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
