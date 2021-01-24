    async Task<int> TaskOfTResult_MethodSync(int delay)
    {
        Debug.WriteLine($"TaskOfTResult_MethodSync delay = {delay}  {DateTime.Now}");
        int hours = 10;
        await Task.Delay(delay);
        Debug.WriteLine($"TaskOfTResult_MethodSync after delay   {DateTime.Now}");
        return hours;
    }
