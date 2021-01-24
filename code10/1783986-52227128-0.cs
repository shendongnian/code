    <tbody>
        @foreach (var weighLocation in Model.WeighLocations)
        {
            <tr>
                <td>@weighLocation.Weigh_Location</td>
                @foreach (var date in Model.CurrentWeekDates)
                {
                    if (Model.WeighAssociations.Any(x => x.tbl_TEUForm.EventDate == date && x.WeighLocationId == weighLocation.ID))
                    {
                        <td>@Model.WeighAssociations.Single(x => x.tbl_TEUForm.EventDate == date && x.WeighLocationId == weighLocation.ID).OccurenceCount</td>
                    }
                    else
                    {
                        <td>0</td>
                    }
                }
            </tr>
        }
    </tbody>
