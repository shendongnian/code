//your model
public class SomeModel
{
   public string test {get;set;}
}
//you view
@model SomeModel
<div id="SettingsTabPanel" class="tabbable-line" style="padding-top:20px;">
 <div id="ProjectTimeLine" class="tab-pane">
   @{ var test = 10;
Model.test = test;
}
   @test
 </div>
  @Html.Partial("~/Views/PortfolioResearch/Partials/_LabUtilization.cshtml", Model)
</div>
//your _LabUtilization partial
@model SomeModel
<span> @Model.test</span>
