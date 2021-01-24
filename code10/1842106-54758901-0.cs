    @model List<SubmissionLine>
    @for (var indexLine = 0; indexLine < Model.Count; indexLine++)
    {
        <tr>
            <input name="[@(TempData["submissionLineCount"])].IdSubmissionLine" value="@(Model[indexLine].IdSubmissionLine)" type="hidden"/>
            <input name="[@(TempData["submissionLineCount"])].IdArticle" value="@(Model[indexLine].IdArticle)" type="hidden"/>
            <input name="[@(TempData["submissionLineCount"])].IdSubmissionSubSection" value="@(Model[indexLine].IdSubmissionSubSection)" type="hidden"/>
            <td>@TempData["submissionLineCount"]</td>
            <td>
                <input name="[@(TempData["submissionLineCount"])].Quantity" value="@(Model[indexLine].Quantity)" type="number" step="0.5" min="0"/>
            </td>
            <td>@Model[indexLine].IdArticleNavigation.Designation</td>
            <td>@Model[indexLine].TotalMaterial</td>
            <td>@Model[indexLine].IdArticleNavigation.UnitPriceMaterial</td>
            <td>@Model[indexLine].TotalSubContractor</td>
            <td>@Model[indexLine].IdArticleNavigation.UnitPriceSubContractor</td>
            <td>@Model[indexLine].TotalWorkforce</td>
            <td>@Model[indexLine].IdArticleNavigation.UnitPriceWorkforce</td>
            <td>
                <input type="checkbox" name="[@(TempData["submissionLineCount"])].IsDisplayed" class="checkbox" value="@(Model[indexLine].IsDisplayed)"/>
            </td>
        </tr>
        {
            TempData["submissionLineCount"] = (Convert.ToInt32(TempData["submissionLineCount"]) + 1);
        }
    }
