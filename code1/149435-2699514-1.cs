     public partial class frmForm1 : Form  // Form1
                {
             public class Account
                    {
                        //some code
        
                    }
        
                    public class ListAcc
                    {
                        //SomeCode
                    }
            }
        
        
         public partial class frmForm2 : Form  // Form2
            {
        
                private void button2_Click(object sender, EventArgs e)
                {
                    //Thats will work
                    frmForm1.ListAcc A = new frmForm1.ListAcc();   
                    string n = A.Data()[0].Usename;
                   
                }
            }
