    public MainWindow(){
        List<person> personList = new List<person>();
    
        personList.Add(new person { name = "rob", age = 32 } );
        personList.Add(new person { name = "annie", age = 24 } );
        personList.Add(new person { name = "paul", age = 19 } );
    
        comboBox1.DataSource = personList;
        comboBox1.DisplayMember = "name";
    
        comboBox1.SelectionChanged += new SelectionChangedEventHandler(comboBox1_SelectionChanged);
    }
        
    void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        person selectedPerson = comboBox1.SelectedItem as person;
        messageBox.Show(selectedPerson.name, "caption goes here");
    }
