using System.Linq;
using System.Text.RegularExpressions;
private void toolStripButton1_Click_1(object sender, EventArgs e)
{
    // Get the textbox just once.
    var textBox = GetRichTextBox();
    // Set the selection color also just once.
    textBox.SelectionBackColor = Color.Orange;
    // get the text to find
    var textToFind = toolStripTextBox1.Text;
    // get the text to search in
    var completeText = textBox.Text;
<strong>
    // escape the text to find because we are using regex to find them
    var escapedTextToFind = Regex.Escape(textToFind);
    // find all the index of the search text int the complete text
    var indexes = Regex.Matches(completeText, escapedTextToFind)
        .OfType&lt;Match&gt;()
        .Select(m =&gt; m.Index);
</strong>
    // select every found index in the textbox
    foreach (var selectionStartIndex in indexes)
    {
        textBox.Select(selectionStartIndex, textToFind.Length);
    }
}
// No needs for invoke, since we want to do UI stuff on the UI thread
public RichTextBox GetRichTextBox()
{
    // instead of null checks, you can use the null conditional operators
    // see: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-conditional-operators
    return tabControl1?.SelectedTab?.Controls?[0] as RichTextBox;
}
