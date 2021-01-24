    @model IEnumerable<Models.User>
    
    @{
      var events= (List<Event>) ViewData["events"]; // Cast events to list
    }
    
    @foreach (var e in @events) // Print the list
    {
      @Html.Label(e.Description);
    }
    
    <table>
        ...
        @foreach (var item in Model)  
        {
          ...  // each user in here in item
        }
    </table>
