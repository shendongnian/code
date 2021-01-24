    @model List<Vidly.Models.Customer>    
    @{
        ViewBag.Title = "Index";
        Layout = "~/Views/Shared/_Layout.cshtml";
    }
    
    <ul>
        @foreach(var customer in Model)
        {
            <li>@customer.Id</li>
            <li>@customer.Name</li>
        }
    </ul>
