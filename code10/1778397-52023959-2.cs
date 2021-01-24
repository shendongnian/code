    public class BaseViewModel
    {	   
        string Name => RootVm.Name;
        int? DateYear => RootVm.SelectedDate.Month;
        int? DateMonth => RootVm.SelectedDate.Month;
    }
