        internal class Domain
        {
            private string name;
            private string renewDate;
            private string client;
            /* Getters, Setters, Constructors, & Other Methods */
            public int LastRenewalDateMonth => int.Parse(renewDate.Split('-')[0]);
            public int LastRenewalDateDay => int.Parse(renewDate.Split('-')[1]);
            public DateTime LastRenewalDate => new DateTime(1901, LastRenewalDateMonth, LastRenewalDateDay);
        }
