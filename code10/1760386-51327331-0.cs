        public List<double> TheThing(int qty, double lowest, double highest, double sumto)
        {
            if (highest * qty < sumto)
            {
                throw new Exception("Impossibru!");
                // heresy
                highest = sumto / 1 + (qty * 2);
                lowest = -highest;
            }
            double rangesize = (highest - lowest);
            Random r = new Random();
            List<double> ret = new List<double>();
            while (ret.Sum() != sumto)
            {
                if (ret.Count > 0)
                    ret.RemoveAt(0);
                while (ret.Count < qty)
                    ret.Add((r.NextDouble() * rangesize) + lowest);
            }
            return ret;
        }
