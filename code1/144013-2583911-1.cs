    public partial class Form1 : Form
    {
      //....
      private void timer1_Tick(object sender, EventArgs e)
      {
        if (this.progressBar1.Value >= 100)
        {
         this.timer1.Stop();
         this.timer1.Enabled = false;
        }
        else
        {
          int tempValue = this.progressBar1.Value + 10;
          if (tempValue < 100 && tempValue >=0 )
          {
           this.progressBar1.Value = tempValue + 1;
           this.progressBar1.Value = tempValue;
          }
          else if (tempValue >= 100)
          {
           this.progressBar1.Value = 100;
           this.progressBar1.Value = 99;
           this.progressBar1.Value = 100;
          }
         this.label1.Text = Convert.ToString(this.progressBar1.Value);                
        }
      }
    //......
    }
