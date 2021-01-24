    foreach (var item in Model.Item2.lParkletApplicationDtos)
            {
        @using (Html.BeginForm("EditCP", "CPDashboard", FormMethod.Post))
        {
            <p>
                Reference Number:
                @Html.DisplayFor(i => i.Item1.REF_NUMBER)
            </p>
            <p>
                Name:
                @Html.DisplayFor(i => i.Item1.NAME)
            </p>
            <p>
                Notes:
                @Html.TextAreaFor(i => i.Item1.NOTES)
            </p>
            
                <p>
                    Title:
                    @Html.DisplayFor(i => item.ParkletTitle)
                </p>
                <br />
                <input type="submit" value="Save" />
            }
        }
