     <select id="Name" name="Name" onchange="this.form.submit()">
        @if (Model.EngineerNameList != null)
        {
            foreach (var Title in Model.EngineerNameList)
            {
           <option value="@Title.EngineerName">@Title.EngineerName</option>
            }
        }
        </select>
