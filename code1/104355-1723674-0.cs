    <asp:TextBox TextMode="MultiLine" ID="txtQuotes" runat="server" Text='<%# ((List<String>) Eval("Quotes")).ToMultiLine() %>' />
    
     public static class ExtensionMethods
        {      
    
            public static string ToMultiLine(this List<String> list)
            {
                return String.Join("\n", list.ToArray()); 
            }
    
    
        }
