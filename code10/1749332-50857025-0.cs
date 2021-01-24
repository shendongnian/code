    label3.Visible = true;
    System.Threading.Tasks.Task.Delay(3000).ContinueWith(_ =>
    {
        Invoke(new MethodInvoker(()=> { label3.Visible = false; }));
    });
