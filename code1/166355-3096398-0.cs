    namespace Myprog
    {
    // I attempt to inform the compiler that I will be wanting an array of the house objects
    // and call that array 'new_house'
    
      List<house> houselist = new List<house>();
    
        private void button1_Click(object sender, EventArgs e)
        {
          // In the programs main routine (not *main*!), I then try to get the
          // array 'new_house' populated with initialised 'house' objects 
          for (int idx = 0; idx < 10; idx++)
           {
              houselist.add(new house());
           }
    
           // And at some point in the future I wish to set or update the values arbitrarily. eg:
            houselist[7].my_id = 123;
            // any combination of attributes and id numbers is possible, so I use zero simply to see if they have been set, with -1 indicating failure / an absence of data-
        }
      }
    }
