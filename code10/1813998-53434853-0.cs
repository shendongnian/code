    @using(Html.BeginForm(........))
    {....
        @{
            var stringList = (List <string>) ViewBag.Deduccionesp;
            for(int i = 0; i < stringList.Count; i ++)
            {
               @Html.Hidden($"DeductionsM[{i}]",stringList[i])
            }
         }
      }
