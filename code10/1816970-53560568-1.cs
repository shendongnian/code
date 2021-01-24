    for each Sections, SubSection, Question...{
                <input name="responses.Index" type="hidden" value="@item.QuestionID" />
                <input name="responses[@item.QuestionID].QuestionID" type="hidden" value="@item.QuestionID" />
    			<input name="responses[@item.QuestionID].SubSectionID" type="hidden" value="@item.SubSectionID" />
    			@Html.DropDownList((string)string.Format("responses[{0}].Response", @item.QuestionID), new SelectList(Model.ResponseList, "Value", "Text"), new { @class = "strucType", @id = "ddl_" + subIndex + Model.Sections[index].SubSections[subIndex].QuestionsList[subsubIndex].QuestionID })
}
                
