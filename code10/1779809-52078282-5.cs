    public class TrainContext
    {
        private static List<Trains> trainList = null;
        public TrainContext()
        {
            if (trainList == null)
            {
                trainList = new List<Trains>();
                trainList.Add(new Trains() { tname = "vaigai", tno = 123, from = "Chennai", to = "trichy" });
                trainList.Add(new Trains() { tname = "express", tno = 456, from = "banglore", to = "chennai" });
            }
        }
        public List<Trains> GetTrains()
        {
            return trainList;
        }
        public void Delete(int TrainNumber)
        {
            if (trainList.Count > 0)
                trainList.Remove(trainList.FirstOrDefault(t => t.tno == TrainNumber));
        }
    }
