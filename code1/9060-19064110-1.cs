    public string RemoveSpecialCharacters(string str)
            {
    
                return Regex.Replace(str, "[^a-zA-Z0-9_]+", "_", RegexOptions.Compiled);
            }
</code 
<br>
**OR**
<br>
         &lt;asp:RegularExpressionValidator ID="regxFolderName" 
         runat="server" ErrorMessage="Enter folder name with  a-z A-Z0-9_" ControlToValidate="txtFolderName" 
    Display="Dynamic" ValidationExpression="^[a-zA-Z0-9_]*$" ForeColor="Red"/&gt;
