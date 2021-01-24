    public class MyListBoxItem {
        public MyListBoxItem(Color c, string m) { 
            ItemColor = c; 
            Message = m;
        }
        public Color ItemColor { get; set; }
        public string Message { get; set; }
    }
    listBox1.Items.Add(new MyListBoxItem(Colors.Green, "10/10"));
    listBox1.Items.Add(new MyListBoxItem(Colors.Red, "0/10"));
    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        // Get the current item and cast it to MyListBoxItem
        MyListBoxItem item = listBox1.Items[e.Index] as MyListBoxItem; 
        if (item != null) 
        {
            e.Graphics.DrawString( // Draw the appropriate text in the ListBox
                item.Message, // The message linked to the item
                listBox1.Font, // Take the font from the listbox
                new SolidBrush(item.ItemColor), // Set the color 
                0, // X pixel coordinate
                e.Index * listBox1.ItemHeight // 
            );
        }
        else 
        {
             // The item isn't a MyListBoxItem, do something about it
        }
    }
