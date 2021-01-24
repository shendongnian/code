    /* when you have the statement below inside the click event 
    handler, you will be creating a new instance of the Confrimation
    class every time the button is clicked. And inside your Confirmation
    class' constructor, you are creating a new instance of Menu class which
    has the property Green. Since Green is a boolean, by default it is set 
    to false and that is your problem.*/
    Confirmation _confirmation = new Confirmation(); 
    private void GButton_Click(object sender, EventArgs e)
        {
            this.Green = true;
            this.Hide();
           
            if (_confirmation == null)
            {
               _confirmation = new Confirmation();
            }
            _confirmation.Show();
        }
