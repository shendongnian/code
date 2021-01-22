              <% switch (Model.ReportType)
              {
                  case (int)ReportType.summary:
                      Html.RenderPartial("Edit/SummaryControl", Model);
                      break;
                  case (int)ReportType.exception:
                      Html.RenderPartial("Edit/ExceptionControl", Model);
                      break;
                  case (int)ReportType.leakdetection:
                      Html.RenderPartial("Edit/LeakDetectionControl", Model);
                      break;
              } %>
