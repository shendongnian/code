    <table>
        <thead>
            .... // add day name headings
        </thead>
        <tbody>
            <tr>
                @for (int i = 0; i < 42; i++)
                {
                    DateTime date = startDate.AddDays(i);
                    if (i % 7 == 0 && i > 0)
                    {
                        @:</tr><tr> // start a new row every 7 days
                    }
                    <td>@date.Day</td>
                }
            </tr>
        </tbody>
    </table>
