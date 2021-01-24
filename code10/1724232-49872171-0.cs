           @for (int i = 0; i < Model.CampusTestResultModelList.Count; i++)
                        {
                            <tr>
                                <td> 
                                  @Html.CheckBoxFor(modelItem=>Model.CampusTestResultModelList[i].RollNumber);
                                     
                                </td>
                                <td>
                                    @Html.DisplayFor(modelItem => Model.CampusTestResultModelList[i].StudentName)
                                </td>
                                <td>
                                  @Html.TextBoxFor(modelItem => Model.CampusTestResultModelList[i].ObtainedMarks, new { @type = "number", min=0, step =1 ,
                                 @class = "numeric-class form-control"})
                                   
                                  @Html.HiddenFor(modelItem => Model.CampusTestResultModelList[i].TotalMarks)
                                </td>
                            </tr>
                        }
