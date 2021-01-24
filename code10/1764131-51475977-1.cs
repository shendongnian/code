      using System.Linq;
      ... 
      Form2 openform = Application
        .OpenForms
        .OfType<Form2>()
        .LastOrDefault(); // in case we have several instances, let's close the last one
      if (null == openform) {
        openform = new Form2();
        
        openform.Show();
      }  
      else {
        openform.Close(); // Or openform.Hide();   
      }
