    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
           
            
            List<string> x = new List<string>();
            x.Add("A");
            x.Add("B");
            x.Add("C");
            x.Add("D");
            x.Add("B");
            List<Client> z = new List<Client>();
            z.Add(new Client() { Name = "A" });
            z.Add(new Client() { Name = "B" });
            z.Add(new Client() { Name = "C" });
            comboBox.Items.AddRange(x.ToArray());
            //comboBox.DisplayMember = "Name";
            //listBox.DisplayMember = "Name";
            //comboBox.Items.AddRange(z.ToArray());
         
        }
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox.Items.Add(comboBox.SelectedItem);
        }
    }
    public class Client
    {
        public string Name { get; set; }
    }
