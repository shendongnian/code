    Dim jsExec As OpenQA.Selenium.IJavaScriptExecutor
    jsExec = CType(driver, OpenQA.Selenium.IJavaScriptExecutor)
    Dim sw As New Stopwatch
    Dim MyListOfWebElements As System.Collections.ObjectModel.ReadOnlyCollection(Of IWebElement)
    Public Sub Selenium_Load_WebElements_By_JsExecutor()
        sw.Restart()
        MyListOfWebElements = jsExec.ExecuteScript("var result = document.querySelector('...here you put your css selector...'); if(result === null) {} else {result = result.querySelectorAll('li')}; return result;")
        sw.Stop()
        MsgBox("WebElement List (jsExec-css) - Loading time (ms): " & sw.ElapsedMilliseconds)
    End Sub
    Public Sub Selenium_Load_WebElements_By_Css()
        sw.Restart()
        MyListOfWebElements = Driver.driver.FindElements(By.CssSelector("...your css selector...")).ToList
        sw.Stop()
        MsgBox("WebElement List (Css) - Loading time (ms): " & sw.ElapsedMilliseconds)
    End Sub
    Public Sub Selenium_Load_WebElements_By_Id()
        sw.Restart()
        MyListOfWebElements = Driver.driver.FindElements(By.Id("...your id...")).ToList
        sw.Stop()
        MsgBox("WebElement List (Id) - Loading time (ms): " & sw.ElapsedMilliseconds)
    End Sub
