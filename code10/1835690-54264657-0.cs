    //Test
    float globalBill;
    
    public Form1()
    {
        InitializeComponent();
        saveGlobalBill();
        Console.WriteLine("Global bill now = " + globalBill); //Console returns 0
    }
    public void saveGlobalBill()
    {
        globalBill += 5;
        Console.WriteLine("In method bill is " + globalBill); //Console returns 5
    }
