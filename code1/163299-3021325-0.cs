    private void test_click(object sender, EventArgs e)
    {
      MessageBox.Show("hi");
      try
      {
         //if it works ok without a error it continues to
         MessageBox.Show("worked ok");
      }
      catch( Exception )
      {  
        //if it encountered a error of some kind it would go to
        MessageBox.Show("DID NOT WORK OK");
      }
    }
