    public partial testclass
    {
      IDictionary<string, string> test_dict= new Dictionary<string, string>();
      String ping_msg
    
      private void test1()
      {
       test_dict = develop.AddPing(ping_msg)
      }
    
      public void call_test1()
      {
        test_dict["NET_MSG"] = "Putting new message";
      }
    
      public void call_test2()
      {
        test_dict["NET_MSG"] = "Putting new message 2";
      }
    
      public void call_test3()
      {
        test_dict["NET_MSG"] = "Putting new message3";
      }
    }
