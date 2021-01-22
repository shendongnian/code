    StreamReader SR;
    string Term_Name;
    string Term_Definition
    SR = File.OpenText(filename);
    Term_Name = SR.ReadLine();
    while(Term_Name != null)
    {
        Term_Definition = SR.ReadLine();
        // make your database call here to insert with these two variables.  I don't know what DB you are using.
        Term_Name = SR.ReadLine();
    }
    SR.Close();
