    // item type to display in the combobox
    public class Item
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
    // build new list of Items
    var data = List<Item>
    {
        new Item{Id = 1, Text = "Item 1"},
        new Item{Id = 2, Text = "Item 2"},
        new Item{Id = 3, Text = "Item 3"}
    };
    // set databind
    comboBox1.DataSource = data;
    comboBox1.ValueMember = "Id";  // the value of a list item should correspond to the items Id property
    comboBox1.DisplayMember = "Text";  // the displayed text of list item should correspond to the items Id property
    
    // get selected value
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedValue = comboBox1.SelectedValue;        
    }
