    public class BoaRegistrationPage
    {
        public IWebDriver Driver;
        private SeleniumKendoDropDownList _dropDownList;
    
        public BoaRegistrationPage(IWebDriver driver)
        {
            this.Driver = driver;
            this._dropDownList = null;
            PageFactory.InitElements(driver, this);
        }
    
        [FindsBy(How = How.Id, Using = "ReportingPeriodName")]
        public IWebElement ReportingPeriodDropDown
        {
            get { return _dropDownList; }
            set { this._dropDownList = new SeleniumKendoDropDownList(value); }
        }
    
        [FindsBy(How=How.Id, Using ="BranchCode")]
        public IWebElement BranchCode { get; set; }
    }
