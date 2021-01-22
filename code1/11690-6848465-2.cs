        class Car
        {
            // Main properties:
            public string Model { get; set; }
            public string Make { get; set; }
            public int InsuranceGroup { get; set; }
            public string OwnerName { get; set; }
            // Read only property combining all the other informaiton:
            public string Info { get { return string.Format("{0} {1}\nOwner: {2}\nInsurance group: {3}", Make, Model, OwnerName, InsuranceGroup); } }
        }
