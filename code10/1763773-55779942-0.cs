        public GetUserPreferencesCall GetEbayUserPreferences()
        {
            if (this.Context == null) // context needs to be defined first
            {
                throw new NullReferenceException("ApiContext is not defined!");
            }
            GetUserPreferencesCall userPreferences = new GetUserPreferencesCall(Context);
            userPreferences.ShowSellerProfilePreferences = true;
            
            try { userPreferences.Execute(); }
            catch (Exception ex)
            {
                // handle exception
            }
            return userPreferences; 
        }
