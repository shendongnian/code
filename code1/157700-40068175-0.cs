            System.Collections.Specialized.StringCollection SavedSearchTerms = new System.Collections.Specialized.StringCollection();
            if (Properties.Settings.Default.SavedSearches != null)
            {
                SavedSearchTerms = Properties.Settings.Default.SavedSearches;
            }
            SavedSearchTerms.Add("Any Value");
            Properties.Settings.Default.SavedSearches = SavedSearchTerms;
