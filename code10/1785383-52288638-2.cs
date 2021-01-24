    textBox1.Leave += new EventHandler((sender2, ee) => 
                {
                    var textBox = (Control)sender2;
                    var date = new DateTime();
                    var testResult = DateTime.TryParse(textBox.Text, out date);
                    var dateToString = String.Format("{0:dd/MM/yyyy}", date);
                    if(testResult==true && textBox.Text.Trim() == dateToString)//Format is the same
                    {
    
                        textBox.Text =dateToString ;
                    }
                    
                    else
                    {
                        textBox.Text = "date wrongly entered.";
                    }
    
                });
