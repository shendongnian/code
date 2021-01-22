    var choices = new Dictionary<string, string>(); 
    choices["A"] = "Arthur"; 
    choices["F"] = "Ford"; 
    choices["T"] = "Trillian"; 
    choices["Z"] = "Zaphod"; 
    listBox1.DataSource = new BindingSource(choices, null); 
    listBox1.DisplayMember = "Value"; 
    listBox1.ValueMember = "Key"; 
