    <div class="form-group">
        @{
           for (int i = 0; i < Model.GetCustomerType.Count(); i++)
           {
                <div class="col-md-10">                       
                   @Html.Label(Model.GetCustomerType[i].Description, new { @class = "control-label col-md-2" })
                   
                   <input type="checkbox" name="selectedCustomerTypes" value="@Model.GetCustomerType[i].Id"
                                         @if (Model.GetCustomerType[i].Selected)
                                          {
                                              <text> Checked</text>
                                          }/>
                   @Html.HiddenFor(model => model.GetCustomerType[i].Id)
                   @Html.HiddenFor(model => model.GetCustomerType[i].Description)
                </div>
           }
        }
    </div>
