    public class Form2
    {
       public event Action<string> SomethingCompleted;
       private void Submit_Click(object sender, EventArgs e)
       {
           SomethingCompleted?.Invoke(txtData.Text);
           this.Close();
       }
    }
