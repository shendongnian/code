    public Form1()
    {
        InitializeComponent();
        FormClosed += Form1_FormClosed;
    }
    private async void btn_ButtonClick(object sender, EventArgs e)
    {
        var isValid = await IsSomethingValid();
        if (isValid && !_isClosed) //<--
        {
            MessageBox.Show("!");
        }
    }
    private void Form1_FormClosed(object sender, FormClosedEventArgs e) => _isClosed = true;
    private async Task<bool> IsSomethingValid()
    {
        await Task.Delay(5000);
        return true;
    }
