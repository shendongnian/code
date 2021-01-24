    @{
         for (int i = 0; i < Model.BrandList.Count(); i++)
         {
              string columbia = "Columbia";
              string choiceRewards = "Choice Rewards Preview";
              if (!Model.BrandList[i].BrandName.Contains(columbia) & !Model.BrandList[i].BrandName.Contains(choiceRewards))
              {
                   var name = Model.BrandList[i];
                   @Html.HiddenFor(model => model.BrandList[i].BrandName)
                   @Html.CheckBoxFor(model => model.BrandList[i].Checked)
                   @Html.LabelFor(model => model.BrandList[i].BrandName, name.BrandName)
                   <br />
               }
         }
    }
