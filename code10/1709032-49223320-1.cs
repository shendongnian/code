    @using Vidly.ViewModels
    @model Vidly.ViewModels.CustomersViewModel
    @{
        ViewBag.Title = "Index";
        Layout = "~/Views/Shared/_Layout.cshtml";
    }
    
    <h2>Customers</h2>
    <ul>
    @foreach (var c in ((CustomersViewModel)ViewData["AnotherCustomers"]).CustomerList)
    {
        <li>@c.Name</li>
    }
    </ul>
