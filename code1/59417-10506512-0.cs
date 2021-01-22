        private void SortCars()
        {
            List<CarSpecs> cars = new List<CarSpecs>();
            List<CarSpecs> carsSorted = new List<CarSpecs>();
            cars.Add(new CarSpecs
            {
                CarName = "Y50",
                CarMaker = "Ford",
                CreationDate = new DateTime(2011, 4, 1),
            });
            cars.Add(new CarSpecs
            {
                CarName = "X25",
                CarMaker = "Volvo",
                CreationDate = new DateTime(2012, 3, 1),
            });
            cars.Add(new CarSpecs
            {
                CarName = "Z75",
                CarMaker = "Datsun",
                CreationDate = new DateTime(2010, 5, 1),
            });
            //More Comprehensive if needed  
            //cars.OrderBy(x => x.CreationDate).ThenBy(x => x.CarMaker).ThenBy(x => x.CarName);
            carsSorted.AddRange(cars.OrderBy(x => x.CreationDate));
            
            foreach (CarSpecs caritm in carsSorted)
            {
                MessageBox.Show("Name: " +caritm.CarName 
                    + "\r\nMaker: " +caritm.CarMaker
                    + "\r\nCreationDate: " +caritm.CreationDate);
            }
        }
    }
    public class CarSpecs
    {
        public string CarName { get; set; }
        public string CarMaker { get; set; }
        public DateTime CreationDate { get; set; }
    } 
