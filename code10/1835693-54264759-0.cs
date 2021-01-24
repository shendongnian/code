    //Test
    float globalBill;
    
    public Form1()
    {
      InitializeComponent();
      saveGlobalBill(ref globalBill);
      Console.WriteLine("Global bill now = " + globalBill); //Console returns 0
    }
    
    public void saveGlobalBill(ref float bill)
    {
       bill += 5;
       Console.WriteLine("In method bill is " + bill); //Console returns 5
    }
