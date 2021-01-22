                TextBox1.Text = "Nitin Luhar";
                Array name=TextBox1.Text.Split(' ');
                foreach (string item in name)
                {
                    for (int i = 0; i < item.Length; i++)
                    {
                        if (i == 0)
                        {
                            Label1.Text = name.GetValue(0).ToString();
                        }
                        if (i == 1)
                        {
                            Label2.Text = name.GetValue(1).ToString();
                        }
                        if (i == 2)
                        {
                            Label3.Text = name.GetValue(2).ToString();
                        }
                    }
                }
            
        
    } 
