    <select name="Cars" multiple class="form-control">
       @if (Model != null)
       {
           for (int i = 0; i < Model.CarsModels.Count(); i++)
           {
               var car = Model.CarsModels[i];
               if (...)
               {
                 <option value="@car" selected>@car</option>
               }
               else
               {
                  <option value="@car">@car</option>
               }
           }
       }
    </select>
