    Dictionary<string, ListBox> _Dictionary;
    public Something() //constructor
    {
       _Dictionary= new Dictionary<string, ListBox>();
       _Dictionary.add("stringname1", ListBox1);
       _Dictionary.add("stringname2", ListBox2);
       _Dictionary.add("stringname3", ListBox3);
    }
    ....
    public void AddToListBox(string listBoxName, string valueToAdd)
    {
      var listBox = _Dictionary[listBoxName];
      listBox.Items.Add(valueToAdd);
    }
