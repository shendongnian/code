            public string bKashNumber { get; set; }
            public string bKashAccountType { get; set; }
    
            public override string ToString()
            {
                return String.Format($"bKash Number-{bKashNumber}, Account Type - {bKashAccountType}");
            }
        }
