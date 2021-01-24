    public void OpenForm()
    {
        if (IsWindowOpen<Window>("EmpHistory"))
            return;
        var taskViewModel = new HistoryEmpViewModel(Convert.ToInt32(SelectedEmploye.MatEmp));
        EmpHistory X = new EmpHistory(taskViewModel);
        X.Name = "EmpHistory";
        X.Show();
    }
