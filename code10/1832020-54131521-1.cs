    var docB = new HtmlDocument();
    docB.LoadHtml(B);
    var docA = new HtmlDocument();
    docA.LoadHtml(A);
    var nodes = docB.DocumentNode.FirstChild.Descendants("p").Select(node => node.InnerHtml)
        .Except(docA.DocumentNode.FirstChild.ChildNodes.Select(node => node.InnerHtml));
    // take note that we are actually doing whatIsInB.Except(whatIsInA), since doing the reverse would result in nothing. There is no &lt;p&gt; in A that is not also present in B
    var result = string.Join(Environment.NewLine, nodes); // will resut in "Three"
    var otherResult = $"<p>{result}</p>"; // "<p>Three</p>"
