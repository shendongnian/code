     if (ViewBag.dbCount != null)
        {
            for (int i = 1; i <= ViewBag.dbCount; i++)
            {
                <ul class="pagination">
                    <li>@Html.ActionLink(@i.ToString(), "Index", "Grid", new { page = @i },null)</li> 
                </ul>
            }
        }
