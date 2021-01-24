    private int nFieldFrom = 0;
    private int nFieldTo = 0;
    private int nRowFrom = 0;
    private int nRowTo = 0;
    private int nNumberFrom = 0;
    private int nNumberTo = 0;
    
    
        //Not necessary for the functionality but it is good to validate the user input
        private bool ValidateInput()
        {
           bool blnValid;
    
           if(!int.TryParse(FieldFrom.Text, out nFieldFrom)
              || !int.TryParse(FieldTo.Text, out nFieldTo)
              || !int.TryParse(RowFrom.Text, out nRowFrom)
              || !int.TryParse(RowTo.Text, out nRowTo)
              || !int.TryParse(NumberFrom.Text, out nNumberFrom)
              || !int.TryParse(NumberTo.Text, out nNumberTo))
            {
              blnValid = false;
            }    
            else
            {
              blnValid = true;
            }
    
          return blnValid;
        }
    
        private void btn_Start_Click(object sender, EventArgs e)
        {
            //This list will contain all your ID's
            List<string> lstResults = new List<string>();
    
            //Every time the button is clicked the user input should be validated
            //GTH field = your 'Friedhof' field
            if(ValidateInput() && !string.IsNullOrEmpty(GTHField.Text))
            {
                for(int f = nFieldFrom; f <= nFieldTo; f++)
                {
                    for(int r = nRowFrom; r <= nRowTo; r++)
                    {
                        for(int n = nNumberFrom; n <= nNumberTo; n++)
                        {
                            lstResults.Add(string.Format("{0} - {1} - {2} - {3}", GTHField.Text, f, r, n));
                        }
                    }
                }
    
                lb_Ausgabe.DataSource = lstResults;
            }
            else
            {
                //error handling
                //for exmaple show a message box
                //MessageBox.Show("....");
            }
        }
