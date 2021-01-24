    @model List<CustomerViewModel>
    <form asp-controller="Customers" .... >
        @for(int i = 0; i < Model.Count i++)
        {
            ....
            <h5>@Model[i].ProjectName</h5>
            @Html.HiddenFor(m => m[i].ProjectName)
            // or <input type="hidden" asp-for-"Model[i].ProjectName />
            <div>
                @for(int j = 0; j < Model[i].EmployeeHours.Count; j++)
                {
                    @Html.HiddenFor(m => m[i].EmployeeHours[j].Employee)
                    @Html.LabelFor(m => m[i].EmployeeHours[j].Hours, Model[i].EmployeeHours[j].Employee)
                    // or <label asp-for="Model[i].EmployeeHours[j].Hours">@Model[i].EmployeeHours[j].Employee</label>
                    @Html.TextBoxFor(m => m[i].EmployeeHours[j].Hours, new { type = "range", ... })
                    // or <input asp-for-"Model[i].EmployeeHours[j].ProjectName type="range" ... />
                }
            </div>
        }
        <input type="submit" value="Save changes" class="btn btn-success" />
    }
