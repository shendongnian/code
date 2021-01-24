    @model WebReportingToolDAL.Models.ViewModels.ReportCategoryListModel
    @{
        ViewBag.Title = "Dashboard";
        Layout = "~/Views/Shared/_Layout.cshtml";
    }
     <body>
        @Html.Raw(ViewBag.Link)
    </body>
