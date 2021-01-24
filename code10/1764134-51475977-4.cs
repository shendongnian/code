      using System.Linq;
      ... 
      // Search: do we have opened Form2 instances?
      Form2 openform = Application
        .OpenForms        // among all opened forms 
        .OfType<Form2>()  // of type Form2
        .LastOrDefault(); // in case we have several instances, let's choose the last one
      if (null == openform) {   // no Form2 instance has been found
        openform = new Form2(); 
        
        openform.Show();
      }   
      else {                    // Instance (openform) has been found 
        openform.Close(); // Or openform.Hide();   
      }
