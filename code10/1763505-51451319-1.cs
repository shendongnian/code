    static bool IsCalled;
    else{ //Player Restart Game
        //////
        /// Check Time for coin bonus
        //////
        if (!IsCalled)
        {
        ButtonCanvas.gameObject.SetActive(false);
        OfflineCanvas.gameObject.SetActive(true);
        if(PlayerPrefs.GetInt("year").Equals(System.DateTime.Now.Year)){ // Same Year
            if(PlayerPrefs.GetInt("month").Equals(System.DateTime.Now.Month)){ // Same Month
                if(PlayerPrefs.GetInt("day").Equals(System.DateTime.Now.Day)){ // Same Day
                    // Add Coin Bouns for hours/min passed
                    offlineCoinCount = PlayerPrefs.GetInt("OfflineCoinsVal") * (((System.DateTime.Now.Hour - PlayerPrefs.GetInt("timeHour")) * 60) + (System.DateTime.Now.Minute - PlayerPrefs.GetInt("timeMin")));
                } else { // Different Day
                    // Update if new day is higher than old
                    if (PlayerPrefs.GetInt("day") < System.DateTime.Now.Month)
                    {
                        PlayerPrefs.SetInt("day", System.DateTime.Now.Year);
                        PlayerPrefs.SetInt("timeHour", System.DateTime.Now.Hour);
                        PlayerPrefs.SetInt("timeMin", System.DateTime.Now.Minute);
                        // Add Coin Bonus For Time 24 hrs
                        offlineCoinCount = PlayerPrefs.GetInt("OfflineCoinsVal") * (24 * 60);
                    }
                }
            } else { // Different Month
                // Update if new month is higher than old
                if (PlayerPrefs.GetInt("month") < System.DateTime.Now.Month)
                {
                    PlayerPrefs.SetInt("month", System.DateTime.Now.Year);
                    PlayerPrefs.SetInt("day", System.DateTime.Now.Year);
                    PlayerPrefs.SetInt("timeHour", System.DateTime.Now.Hour);
                    PlayerPrefs.SetInt("timeMin", System.DateTime.Now.Minute);
                    // Add Coin Bonus For Time 24 hrs
                    offlineCoinCount = PlayerPrefs.GetInt("OfflineCoinsVal") * (24 * 60);
                }
            }
        } else { // Different Year
            // Update if new year is higher than old
            if(PlayerPrefs.GetInt("year") < System.DateTime.Now.Year){
                PlayerPrefs.SetInt("year", System.DateTime.Now.Year);
                PlayerPrefs.SetInt("month", System.DateTime.Now.Year);
                PlayerPrefs.SetInt("day", System.DateTime.Now.Year);
                PlayerPrefs.SetInt("timeHour", System.DateTime.Now.Hour);
                PlayerPrefs.SetInt("timeMin", System.DateTime.Now.Minute);
                // Add Coin Bonus For Time 24 hrs
                offlineCoinCount = PlayerPrefs.GetInt("OfflineCoinsVal") * (24 * 60);
            }
        }
        IsCalled = true;
    }
    }
