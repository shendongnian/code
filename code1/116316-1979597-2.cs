    var pmLogOnName = Html.CreatePopUpMenu("pmLogOnName")
                          .AddMenuItem("mLogOnName-RememberMe", "Remember UserName", isCheckBox: true, isSelected: true);
    Html.CreateTextBox("txtLogOnName", 1)
        .BindData(Model, x => x.LogOnName, "showError")
        .WaterMark(LogOnView.LogOnName)
        .BindMenu(pmLogOnName)
