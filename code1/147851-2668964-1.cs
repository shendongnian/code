    private void mainForm_Load(object sender, EventArgs e) 
    {
        string fileName = @"..\..\MealDeliveries.txt";
        if (!File.Exists(fileName))
        {
            MessageBox.Show("File not found!");
            return;
        }
        using (StreamReader sr = new StreamReader(fileName))
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
