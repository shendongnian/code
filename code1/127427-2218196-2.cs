    private void Form1_Load(object sender, EventArgs e)
    {
        foreach (var controlTag in XDocument.Load("settings.xml").Root.Elements())
        {
            var controlType = Type.GetType(string.Format("System.Windows.Forms.{0}, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", controlTag.Name.LocalName), false);
            if (controlType == null || !typeof(Control).IsAssignableFrom(controlType))
            {
                continue;
            }
            var control = (Control)Activator.CreateInstance(controlType);
            control.Text = controlTag.Attribute("Content").Value;
            control.Location = new Point(
                int.Parse(controlTag.Attribute("LocationX").Value),
                int.Parse(controlTag.Attribute("LocationY").Value)
            );
            control.BackColor = Color.Transparent;
            control.MouseClick += mouseClick;
            control.MouseDown += mouseDown;
            control.MouseMove += mouseMove;
            control.MouseUp += mouseUp;
            control.MouseDoubleClick += mouseDoubleClick;
            Controls.Add(control);
        }
        
    }
