    public MyPage1()
    {
       //...
       MessagingCenter.Subscribe<Object, int>(this, "ClickSegmentedControl", (sender, arg) =>
       {
                Console.WriteLine(arg); //arg is num of the segment that you clicked.
       });
    } 
