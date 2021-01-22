    private void mainForm_Load(object sender, EventArgs e) 
    {
        if (!File.Exists(@"..\..\MealDeliveries.txt"))
        {
            MessageBox.Show("File not found!");
            return;
        }
        using (StreamReader sr = new StreamReader("../../MealDeliveries.txt"))
        {
            //first line is delivery name 
            string strDeliveryName = sr.ReadLine(); 
            while (strDeliveryName != null)
            { 
                //other lines 
                Delivery d = new Delivery(strDeliveryName, sr.ReadLine(),
                                          sr.ReadLine(), sr.ReadLine(),
                                          sr.ReadLine(), sr.ReadLine(),
                                          sr.ReadLine());
                mainForm.myDeliveries.Add(d);
                //check for further values
                strDeliveryName = sr.ReadLine();
            }
        }
        displayDeliveries();
    }
