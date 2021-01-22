    foreach (Control c in Page.Controls)
    {
       if (c is Textbox)
       {
           (Textbox)c.Color.blah.blah.blah ;)
       }
       ///etc
       Recurse through (c.Controls);
    }
