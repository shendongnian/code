    foreach (CD testCD in _cdCollection)
        {
            if (testCD.Track.Contains(track))
            {
                //Return the matching CD
                return testCD;
            }
        }
