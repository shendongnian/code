        public OpenQA.Selenium.By Control { get; set; }
        public string ControlName { get; set; }
        public ByControlWithName(OpenQA.Selenium.By ctl, string name)
        {
            this.Control = ctl;
            this.ControlName = name;
        }
        
    }
