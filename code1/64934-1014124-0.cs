    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
    }
    public class CarComparer : IComparer
    {
        string sortColumn;
        public CarComparer(string sortColumn)
        {
            this.sortColumn = sortColumn;
        }
        public int Compare(object x, object y)
        {
            Car carX = x as Car;
            Car carY = y as Car;
            if (carX == null && carY == null)
                return 0;
            if (carX != null && carY == null)
                return 1;
            if (carY != null && carX == null)
                return -1;
            switch (sortColumn)
            {
                case "Make":
                    return carX.Make.CompareTo(carY.Make);
                case "Model":
                    return carX.Model.CompareTo(carY.Model);
                case "Year":
                default:
                    return carX.Year.CompareTo(carY.Year);
            }
        }
    }
