    XElement root = XElement.Load(@"your path to a file");
    //set text box to some default value to test if function will work
    textBox1.Text = "10.1.4";
    //here I used etension method, commented is alternative version, for better understanding
    IEnumerable<XElement> tests = root.Elements("group").Where(gr => gr.Elements("ip").Any(ip => ip.Value == textBox1.Text));
    //IEnumerable<XElement> tests = root.Elements("group").Where(gr => gr.Elements("ip").Where(ip => ip.Value == textBox1.Text).Count() > 0);
    foreach (XElement el in tests)
        //Console.WriteLine((string)el.Attribute("name"));
        MessageBox.Show((string)el.Attribute("name"));
