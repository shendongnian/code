    string[] searchText = new string[3];
    for(int i = 1; i<=3; i++)
       {
            searchText[i] = options.Control["scCB" + i.Tostring()] +
                            options.Control["ops" + i.Tostring()] +
                            options.Control["cr" + i.Tostring()];
       }
