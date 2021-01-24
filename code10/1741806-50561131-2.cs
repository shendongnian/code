    public class PageObjectTest extends Page {
        @FindBy(id = "firstName")
        private WebElement inputFirstName;
    
        @FindBy(id = "lastName")
        private WebElement inputMiddleName;
    
        @FindBy(xpath = "//button[@type='submit']")
        private WebElement buttonSubmit;
    
        public PageObjectTest(WebDriver driver) {
            super(driver);
            PageFactory.initElements(driver, this);
        }
    }
