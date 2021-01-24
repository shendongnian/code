    public String getGridColumnFromTable(WebElement tableDivElement, String headerColumn) {
        WebElement newElement = waitUntilElementIsClickable(tableDivElement);
        WebElement contextContainer = null;
        String headerXPath = ".//child::div[contains(@id,'headercontainer')]/child::div/child::div/child::div/child::div/span[.='" + headerColumn + "']";
        WebElement headerGridColumn = newElement.findElement(By.xpath(headerXPath));
        waitUntilElementIsClickable(headerGridColumn);
        String contextContainerXpath = ".//parent::div/parent::div";
        contextContainer = headerGridColumn.findElement(By.xpath(contextContainerXpath));
        String gridColumnID = contextContainer.getAttribute("id");
        waitForPostBack();
        return gridColumnID;
    }
