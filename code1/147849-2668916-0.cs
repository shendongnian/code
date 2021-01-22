    using (StreamReader sr = new StreamReader("../../MealDeliveries.txt"))
    {
                //first line is delivery name
                string strDeliveryName = sr.ReadLine();
                do
                {
                    //other lines
                    Delivery d = new Delivery(strDeliveryName, sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine());
                    mainForm.myDeliveries.Add(d);
                    //check for further values
                    strDeliveryName = sr.ReadLine();
                    //stop if no more values
                } while (strDeliveryName != null);
                displayDeliveries();
    }
