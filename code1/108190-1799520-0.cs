    string s1 = "MyFirstString";
    string s2 = "Another different string";
    Font f1 = new Font("Arial", 12f);
    Font f2 = new Font("Times New Roman", 14f);
    Graphics g = CreateGraphics();
    SizeF sizeString1 = g.MeasureString(s1, f1),
          sizeString2 = g.MeasureString(s2, f2);
    float offset = sizeString2.Width - sizeString1.Width / 2;
    // Then offset (to the Left) the position of the label 
    // containing the second string by this offset value...
    // offset to the left, because If the second string is longer,  
    // offset will be positive.
    Label lbl1 = // Label control for string 1,
          lbl2 = // Label control for string 2;
    lbl1.Text = s1; lbl1.Left = //Some value;
    lbl2.text = s2; lbl2.Left == lbl1.Left - offset;
    
