    file.ReadLine();
    string line = "";
    try
    {
        while ((line = file.ReadLine()) != null)
        {
            string[] splitArray = line.Split('|');
            Listing.Add(new List(splitArray[1], splitArray[2], splitArray[3]));
            count++;
        }
    }
    catch
    {
        MessageBox.Show("Nothing to do here...");
    }
    file.Close();
