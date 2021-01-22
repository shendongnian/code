       // on the Form where the TextBoxes are : a Form-level variable
        private List<TextBox> tbList;
        
        // build the list of TextBoxes and set the same 'Enter event for each of them
        // note the assumption that every TextBox on the Form is going to be handled
        // in exactly the same way : probably better to isolate them in a Panel in case
        // you have other TextBoxes for other purposes ; then you'd just use the same
        // code here to enumerate all the TextBoxes in the Panel
        private void Form1_Load(object sender, EventArgs e)
        {
    		 tbList =
    		 (
    		    from TextBox theTB in this.Controls.OfType<TextBox>()
    		    select theTB
    		 ).ToList();
    		 
    		 foreach (TextBox theTB in tbList)
    		 {
    		    theTB.KeyPress +=new KeyPressEventHandler(theTB_KeyPress);
    		    theTB.Enter +=new EventHandler(theTB_Enter);
    		 }
        }
        
        // so here's what the Enter event might look like :
        private void theTB_Enter(object sender, EventArgs e)
        {
            theActiveTB = (TextBox)sender;
        
            // reality check ...
            // Console.WriteLine("entering : " + theActiveTB.Name);
        }
        
        // so here's what the KeyPress event might look like :
        private void theTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            // do what you need to do here
        
            // access the Text in the Textbox via 'theActiveTB
        
            // reality check
            // Console.WriteLine(theActiveTB.Name + " : " + e.KeyChar );
        }
