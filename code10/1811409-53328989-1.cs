    /* when you have the statement below inside the click event 
    handler, you will be creating a new instance of the Confrimation
    class every time the button is clicked. And inside your Confirmation
    class' constructor, you are creating a new instance of Menu class which
    has the property Green. Since Green is a boolean, by default it is set 
    to false and that is your problem.*/
    Confirmation _confirmation; 
    /* once you have moved the creation of Confirmation class outside the 
    button click event, you will be working with the same instance that you
    initially created and that instance will have the value of Green to whatever
    you had set it to. */
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
