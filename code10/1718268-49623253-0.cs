    public class Room
        {
            public  int Width { get; set; }
            public int Length { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }
    private void btnFillCombo_Click(object sender, EventArgs e)
            {
                foreach (KeyValuePair<int,Room> rm in dctRoom)
                {
                    comboBox1.Items.Add(rm.Value);
                }
            }
    
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                Room rm = (Room)comboBox1.SelectedItem;
                Debug.Print($"Name is {rm.Name}, Width is {rm.Width}, Length is {rm.Length}");
            }
