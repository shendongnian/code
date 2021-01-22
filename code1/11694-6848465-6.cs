        private void Form1_Load(object sender, System.EventArgs e)
        {
            // Set up a list of cars:
            List<Car> allCars = new List<Car>();
            allCars.Add(new Car { Make = "Toyota", Model = "Yaris", InsuranceGroup = 6, OwnerName = "Joe Bloggs" });
            allCars.Add(new Car { Make = "Mercedes", Model = "AMG", InsuranceGroup = 50, OwnerName = "Mr Rich" });
            allCars.Add(new Car { Make = "Ford", Model = "Escort", InsuranceGroup = 10, OwnerName = "Fred Normal" });
            
            // Attach the list of cars to the ListBox:
            lstCars.DataSource = allCars;
            lstCars.DisplayMember = "Model";
        }
