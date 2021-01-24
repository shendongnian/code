    @{
        string currentLocation1 = "";
        string currentLocation2 = "";
        string dayStop1 = "Sunday";
    }
    
    <table>
        <thead>
            <tr>
                @foreach (var item in location.GroupBy(x => x.Day).Select(x => x.First()))
                {
                    if (item.CampusName != currentLocation1)
                    {
                        <th style='width:150px;'>Location</th>
                        currentLocation1 = item.CampusName;
                    }
                    if (item.Day != dayStop1)
                    {
                        <th style='width:150px;'>@item.Day</th>
                    }
                }
            </tr>
        </thead>
        <tbody>
            @foreach (var item in location.GroupBy(x => x.CampusName))
            {
                <tr>
                    @foreach (var innerItem in item)
                    {
                        if (innerItem.CampusName != currentLocation2)
                        {
                            <td>@innerItem.CampusName</td>
                            currentLocation2 = innerItem.CampusName;
                        }
                        if (innerItem.Day != dayStop1)
                        {
                            <td>@innerItem.OpenHours</td>
                        }
                    }
                </tr>
            }
        </tbody>
    </table> 
