    <table>
            <tr>
                <td>Status: </td>
                <td>
    if(@Model.StatusChoice.FirstOrDefault() != null && @Model.StatusChoice.FirstOrDefault().CurrentStatus != ""){
                    <input type="text" name="txtStatus" value="@Model.StatusChoice.FirstOrDefault().CurrentStatus" />
    }
    else{
    <input type="text" name="txtStatus" value="Missing" />
    }
                </td>
            </tr>
    </table>
