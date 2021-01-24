    private async void button1_Click(object sender, EventArgs e)
    {
        await Process1();
    }
    private async Task Process1()
    {
        packProcesses++;
        busy = true;
        Trace.WriteLine("PROCESSES " + packProcesses + " busy? " + busy);
        //Do something
        var result = await DelayAndReturnAsync(v);
        //finished?
        packProcesses--;
        if (packProcesses <= 0) busy = false;
        Trace.WriteLine("Processes " + packProcesses + " busy? " + busy);
    }
    private async void button2_Click(object sender, EventArgs e)
    {
        await Process2();
    }
    private async Task Process2()
    {
        packProcesses++;
        busy = true;
        Trace.WriteLine("PROCESSES " + packProcesses + " busy? " + busy);
        //Do something
        var result = await DelayAndReturnAsync(v);
        //finished?
        packProcesses--;
        if (packProcesses <= 0) busy = false;
        Trace.WriteLine("Processes " + packProcesses + " busy? " + busy);
    }
