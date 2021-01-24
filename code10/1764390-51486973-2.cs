    <h1>@Model.Year</h1>
    @foreach (var groupMonth in Model.Records.GroupBy(recordLists => new { recordLists.date.Value.Year, recordLists.date.Value.Month }))
            {
                <h3 class="monthHeader"> @System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(groupMonth.Key.Month)</h3>
                foreach (var recordLists in groupMonth)
                {
                    <div class="row">
                        @Html.Partial("_PartialView", recordList)
                    </div>
                }
            }
