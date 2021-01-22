            TextBox tmpLog = new TextBox(); // create new control of textbox type
            tmpLog.Text = "some text here";
            TabPage tb = new TabPage("my brand new tab"); //create tab
            tabControl.TabPages.Add(tb); // add tab to existed TabControl
            tb.Controls.Add(tmpLog); // add textBox to new tab
            tabControl.SelectedTab = tb;     // activate tab
