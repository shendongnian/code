    public class DataContainer
    {
        public string SomeData{get;set;}
    }
    
    public class Form1:Form
    {
       private DataContainer _container;
       public Form1(DataContainer container)
       {
          _container=container;
       }
    
       private void richTextBox1_TextChanged(object sender, EventArgs e) 
       { 
           _container.SomeData = richTextBox1.Text; 
       } 
       
       private void SpawnForm2()
       {
          var form2=new Form2(_container);
          form2.Show();
    }
    
    public class Form2:Form
    {
       private DataContainer _container;
       public Form2(DataContainer container)
       {
         _container=container;
       }
    }
