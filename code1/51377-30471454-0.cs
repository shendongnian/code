      Main()
       {
        ChangeProperties(ref category,True);    //Where Category is the ID  of the Textbox control  i.e <asp:textbox ID="Category "></textbox>
        }
       public void ChangeProperties(ref TextBox category,bool val)
        { 
          category.Enabled = val;
         }
