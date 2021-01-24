    @if (Model != null && Model.Count > 0)
    {
    <table class="table table-hover">
        <thead>
            <tr>
                <th>
                    Skill Category
                </th>
                <th>
                    Skill
                </th>
                <th>
                </th>
            </tr>
        </thead>
        <tbody>
            @foreach (var fam in Model.ToList())
            {
               
                    <tr>
                        <td>
                            @fam.Skill.SkillCategory.Description
                        </td>
                        <td>
                            @fam.Skill.Description
                        </td>
                        <td>
                            using (@Html.BeginForm("Delete", "Skill", new { id = @fam.SkillId }))
                            {
                            @Html.Hidden("SkillId", fam.SkillId)
                            <input type="submit" value="Delete" class="btn btn-link">
                            }
                        </td>
                    </tr>
               
            }
        </tbody>
    </table>
    }
     else
     {
        @Html.DisplayText("Skills not added, please add")
      }
