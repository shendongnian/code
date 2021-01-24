       @(Html.Kendo().Grid<FuelActivityTrackerDal.Models.ActivityHeader>()
         .Name("grid")
         .Columns(columns =>
            {
              columns.Bound(p => p.Description).Filterable(false);
              columns.Bound(p => p.Name);
              columns.Bound(p => p.ActivityDate).Format("{0:MM/dd/yyyy}");
                                            columns.Bound(p => p.EmployeeName);
                                            columns.Bound(p => p.Status);
                                            columns.Command(command => { command.Edit(); command.Destroy(); }).Width(160);
              })
             .ToolBar(toolbar => toolbar.Create())
             .Editable(editable => editable.Mode(GridEditMode.PopUp))
             .Scrollable()
 
              .Pageable()
               .Sortable()
               .Filterable() 
               .DataSource(dataSource => dataSource
               .Ajax()
               .Events(events => events.Error("error_handler"))
               .Model(model => model.Id(p => p.ActivityHeaderId))
               .PageSize(Model.Count())
               .Read(read => read.Action("Activity_Read", "Activity"))
               .Update(update => update.Action("EditingPopup_Update", "Activity").Type(HttpVerbs.Post))
                 
                  )
                )
