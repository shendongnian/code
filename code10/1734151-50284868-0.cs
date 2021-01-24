    /// <summary>
    /// Returns the text of the specified child text node.
    /// </summary>
    /// <param name="parentElement">The parent <see cref="IWebElement"/> of the desired text node.</param>
    /// <param name="index">The index of the childNode collection relative to parentElement</param>
    /// <returns>The text of the specified child text node.</returns>
    public string GetChildTextNode(IWebElement parentElement, int index = 0)
    {
        string s = (string)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].childNodes[arguments[1]].textContent;", parentElement, index);
        return s.Trim();
    }
