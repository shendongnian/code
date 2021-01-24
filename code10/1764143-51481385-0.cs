    private Form myForm = null;
    public void OnButton1_Clicked(object sender, ...)
    {
        if (this.myform == null)
        {   // not shown yet. Show it now:
            this.myForm = new Form2()
            this.myForm. properties = ...
            // make sure I get notified if the Form closes in any way:
            this.myForm.Closed += onMyFormClosed;
            // show the form
            this.myform.Show(this);
        }
        else
        {   // ask the form nicely to close itself
            this.CloseForm(); 
            // this might (or might not) lead to the event Form.Closed
        }
    }
    private void OnMyFormClosed(object sender, ...)
    {
         if (!object.ReferenceEquals(sender, this.myForm))
         {    // someone else is closed. I have nothing to do with this
              return;
         }
         // if here, my Form is closed. Save to Dispose and assign Null
         this.myForm.Dispose();
         this.myForm = null;
    }
    }
    public void ShowFo
