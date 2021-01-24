    //This is the HiddenField used to capture the users identified session name
    //which I then store in a DB and use in a few other related pages.
    <asp:HiddenField ID="HiddenField1" ClientIDMode="Static" runat="server" /> 
  
    //This is the ASP button used to call both the Javascript and C# code behind  
        <asp:Button ID="btnRateBeazely" ClientIDMode="Static" runat="server" CssClass="btnbig" Text="Rate Beazley" OnClick="btnRateBeazely_Click" OnClientClick="getSessionName();" />
    //The Javascript is simple, but does exactly what I want it to. DB has character
    //limit to 50 so I ensure the user can't input higher than that. Assign the input
    //to the hiddenfield ID and off we go.  
    
    function getSessionName() {
    var SessionSet = prompt("Please enter your session name"); 
    while (SessionSet.length > 49) {
        alert("You have too many characters. Please enter again.")
        var SessionSet = prompt("Please reenter your session name"); 
    }
    document.getElementById("HiddenField1").value = SessionSet;
    
}
    //In the code behind I just assign a new string variable to the hidden field value 
