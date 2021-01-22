    private BusinessLogic Task;
    private void Form1_Load(object sender, EventArgs e)
    {
        Task = new BusinessLogic();
        Task.ProgressChanged += Task_ProgressChanged;
    }
    void Task_ProgressChanged(object sender, EventArgs e)
    {
        taskProgessBar.Value = ((BusinessLogic) sender).Progress;
    }
