    public void digitButtons_Click(object sender, EventArgs eventArgs) {
        if(sender is Button) {
            string digit = (sender as Button).Text;
            // TODO: do magic
        }
    }
    
    public void createButtons() {
        for(int i = 0; i < 10; i++) {
            Button button = new Button();
            button.Text = i.ToString();
            button.Click += digitButtons_Click;
            // TODO: add button to Form
        }
    }
