    public class TrainContext
    {
        private static List<Trains> trainList = null;
        public static List<Trains> TrainList
        {
            get
            {
                if (TrainList == null)
                {
                    trainList = new List<Trains>();
                    trainList.Add(new Trains() { tname = "vaigai", tno = 123, from = "Chennai", to = "trichy" });
                    trainList.Add(new Trains() { tname = "express", tno = 456, from = "banglore", to = "chennai" });
                }
                return trainList;
            }
        }
    }
