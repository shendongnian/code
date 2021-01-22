    foreach(Control c in form.Controls)
    {
       if(c is Textbox)
          HandleTextbox((Textbox)c); 
          //c is always guaranteed to be a Textbox here because of is 
       if(c is Listbox)
          HandleListbox((Listbox)c); 
          //c is always guaranteed to be a Listbox here because of is 
    }
