    public partial class Form1 : Form
    {
   
         private ILocalHueClient client
         ....
        private void button1_Click(object sender, EventArgs e)
        {
            client.SendCommandAsync(command);
        }
