        int xlocation = 5;
        for (int i = 1; i <= 5; i++)
        {
             Button newButton = new Button();
             {
                 newButton.Name = string.Format("Button{0}", i);
                 newButton.Text = string.Format("Button {0}",i);
                 newButton.Location = new System.Drawing.Point(xlocation, 10);
                 newButton.Size = new System.Drawing.Size(75, 35);
                 newButton.Click += btn_msg;
                 this.Controls.Add(newButton);
             }
             xlocation = xlocation + 85;
        }
