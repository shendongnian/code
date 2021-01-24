    public class Form1
    {
       ...
       public void submit()
       {
           ...
           //Here you are calling form2
           //Pass timer instance a parameter to form2
           Form2 form2Instance = new Form2(timer);
           form2Instance.Show();
       }
    
    }
