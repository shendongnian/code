    private List<double> GetAnnualTuitions(double originalTuition, double interestRate, int numOfYears)
        {
            double newTuition = 0;
            List<double> tuitions = new List<double>();
            for (int year = 1; year <= numOfYears; year++)
            {
                if (year == 1)
                {
                    newTuition = originalTuition;
                }
                else
                {
                    newTuition += (newTuition * interestRate);
                }
                tuitions.Add(newTuition);
            }
            return tuitions;
        }
