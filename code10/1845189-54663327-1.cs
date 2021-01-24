    //label
    Label label2 = new Label();
    label2.Location = new System.Drawing.Point(6, 68);
    label2.Name = "label2";
    //label2.Size = new System.Drawing.Size(24, 13);
    label2.TabIndex = 16;
    label2.Text = "Characteristic Strength Qd:";
    label2.AutoSize = true;
    // ADD IT TO THE PANEL IN ORDER TO GAIN A WIDTH
    Fixidity_panel.Controls.Add(label2);
    label2.MouseHover += new EventHandler(BoucWen_Qd_MouseHover);
    //textbox
    TextBox textBox3 = new TextBox();
    // NOW YOU CAN DO:  .Location = label2.X+label2.Width+5
    textBox3.Location = new System.Drawing.Point(label2.Location.X+label2.Width +5, 65);
    textBox3.Name = "Qd";
    textBox3.Size = new System.Drawing.Size(197, 20);
    textBox3.TabIndex = 17;
    textBox3.Tag = "Characteristic Strength\r\n Link: )_Element";
    // NOW ADD THE TEXTBOX
    Fixidity_panel.Controls.Add(textBox3);
