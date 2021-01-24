    using System.Threading.Tasks;
    private async void button1_Click(object sender, EventArgs e)
    {
         button1.Enabled = false;
         await DoWorkAsync(e);
         MessageBox.Show("Done!");
         button1.Enabled = true;
    }
        
    private async Task DoWorkAsync(object value)
    {
        await Task.Run(() =>
        {
           //Some work
        });
    }
