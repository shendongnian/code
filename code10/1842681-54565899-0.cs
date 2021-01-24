csharp
[Fact]
public void ProblemWithOriginalSolution()
{
    NameValueCollection outgoingQueryString = HttpUtility.ParseQueryString(String.Empty);
    outgoingQueryString.Add("Param1", "Value1");
    outgoingQueryString.Add("Param2", "Value2=Something"); // this '=' needs to remain URL-encoded
    outgoingQueryString.Add("OtherParams", "Enable_Filter_Show_on_Action_Report=0");
    var queryString = outgoingQueryString.ToString().Replace("%3d", "=");
    Assert.Contains("Value2=Something", queryString); // Passes, but not what we want
    Assert.Contains("Value2%3dSomething", queryString); // Actually what we want, but fails
}
That might not matter for your needs, but if it does, I have two suggestions.
The first is to just use string concatentation. Depending on your use, this might need extra logic to handle the case where `OtherParams` is the only query string parameter (the ampersand should be omitted in that case). String concatenation is also a bad idea of `OtherParams` might contain characters that need to be URL encoded.
csharp
[Fact]
public void Concatentation()
{
    NameValueCollection outgoingQueryString = HttpUtility.ParseQueryString(String.Empty);
    outgoingQueryString.Add("Param1", "Value1");
    var queryString = outgoingQueryString.ToString() + "&OtherParams=Enable_Filter_Show_on_Action_Report=0";
    Assert.Contains("&OtherParams=Enable_Filter_Show_on_Action_Report=0", queryString);
}
The second is to do a double-substitution. This is a bit heavy-handed, and not terribly efficient, but should be reliable.
csharp
[Fact]
public void DoubleSubstitution()
{
    // Make sure the placeholder doesn't have any characters that will get URL encoded!
    // Also make sure it's not something that could appear in your input.
    const string equalsPlaceholder = "__Equals__";
    NameValueCollection outgoingQueryString = HttpUtility.ParseQueryString(String.Empty);
    outgoingQueryString.Add("Param1", "Value1");
    // First, remove the equals signs from the OtherParams value
    outgoingQueryString.Add("OtherParams", "Enable_Filter_Show_on_Action_Report=0".Replace("=", equalsPlaceholder));
    // Then, build the query string, and substitute the equals signs back in
    var queryString = outgoingQueryString.ToString().Replace(equalsPlaceholder, "=");
    Assert.Contains("&OtherParams=Enable_Filter_Show_on_Action_Report=0", queryString);
}
