        @(Html.Kendo().DropDownList()
            .Name("Employee") // The name of the widget should be the same as the name of the property.
            .DataValueField("EmployeeID") // The value of the dropdown is taken from the EmployeeID property.
            .DataTextField("EmployeeName") // The text of the items is taken from the EmployeeName property.
            .BindTo((System.Collections.IEnumerable)ViewData["employees"]) // A list of all employees which is populated in the controller.
        )
