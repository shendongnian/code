for (int i = 0; i < values.Length; i++)
{
   listBox1.Items.Add(values[i].ToString());  //values[i] never has a star stored in it!
}
How about something like this...?
 public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[] values = new [] { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text };
            
            for (int i = 0; i < values.Length; i++)
            {
                if (listBox1.Items.Count < i + 1)
                {
                    listBox1.Items.Add(values[i].ToString());
                    continue;
                }
                string unedited = listBox1.Items[i].ToString();
                if (!string.IsNullOrEmpty(unedited) && unedited.Last() == '*')
                    unedited = listBox1.Items[i].ToString().Substring(0, listBox1.Items[i].ToString().Length - 1);
                if (unedited != values[i])
                    listBox1.Items[i] = values[i] + "*";
                else
                    listBox1.Items[i] = values[i];
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
This compares the list items to the textbox values.  
If the textbox value doesn't exist, a listbox item is created.  
If the listbox item doesn't match the textbox value, it has a `*` appended to it.  
If an existing value (ignoring the star) is the same as the textbox value, it is updated to ensure the star is removed.
