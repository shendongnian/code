    StringBuilder strbuild = new StringBuilder();
    // Put resource into using statements, for deterministic cleanup
    using (TextReader reader = new StreamReader("buf.txt", System.Text.Encoding.ASCII))
    {
        string line;
        //Maybe looks a little ugly the first time, but is commonly used to
        //process all the lines of a file (.ReadToEnd() can cause memory problems
        //on really big files)
        while ((line = reader.ReadLine()) != null)
        {
            //Instead of if, else if, else if, etc just take a switch
            //statement. Makes it much easier to read.
            switch (line[0])
            {
                //If you need case insensitivity put both versions of the character
                //before your first line of code
                case 'A':
                case 'a':
                    strbuild.Append(line);
                    break;
                //Otherwise just use the lower or upper case version you like
                case 'B':
                    strbuild.Append("BET");
                    break;
            }
        }
    }
    //Put the result of the StringBuilder directly into the Show() function
    MessageBox.Show(strbuild.ToString());
