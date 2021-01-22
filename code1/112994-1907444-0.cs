    int[,] array2DB = new int[2, 30];
        for (int i = 0; i < 30; i++)
        {
            string txbName = "br" + i + "txt" + '3';
    
            TextBox txtBCont1 = (TextBox)this.Controls[txbName];
    
            string string1 = txtBCont1.Text.ToString();
            UpdateFormClass.runUserQuery(string1);
    
            array2DB[0,i] = int.Parse(UpdateFormClass.gamleSaker.ToString());
            array2DB[1,i] = int.Parse(UpdateFormClass. nyeSaker.ToString());
    
        }
