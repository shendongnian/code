IWebElement tableElement = driver.FindElement(By.XPath("//div[@id='table']"));
IList<IWebElement> tableDataElements = tableElement.FindElements(By.TagName("td"));
var reults = new List<string>();
foreach (IWebElement tableDataElement in tableDataElements)
{
	var tableData = tableDataElement.Text;
	reults.add(tableData);
}
return reults;
