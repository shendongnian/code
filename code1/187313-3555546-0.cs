    public int RateMyUser(int MaxStars, int MinThreshold, int MarksObtained)
        {
            int division = 0;
            int stars = 0;
            // this will give division of remaining score greater than passing percentage<br>
            division = (100 - MinThreshold) / MaxStars;
            if (MarksObtained >= MinThreshold)
            {
                // obtain the stars to be given
                stars = (MarksObtained - MinThreshold) / division; // integer representing stars
                return stars + 1;
            }
            return stars;
        }
