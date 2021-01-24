    try
    {
        //Code to try open the file to memory
    }
    catch (Exception ex)
    {
        while (true)
        {
            MessageBox.Show(@"Select an valid file");
            var path = searchFile();
            if (string.IsNullOrWhiteSpace(path))
                continue;
            try
		    {
			    //Code to try open the file to memory
		    }
		    catch (Exception ex2)
		    {
			    MessageBox.Show(@"The selected file is not valid");
    			continue;
            }
            break;
        }
	}
