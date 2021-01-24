    public static bool IsOverLapping(ConfigureViewModel viewModel)
    {
        bool status = false;
        var times = viewModel.Periods.OrderBy(x => x.StartTime.TimeOfDay).ToList();
        return times.IsOverLapping();
    }
