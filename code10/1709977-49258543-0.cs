    var item = line[line.Count - 1];
    if (item.Contains("success"))
    {
        MessageBox.Show("Successful processing");    
    }
    else
    {
        MessageBox.Show("There was an error.");
    }
