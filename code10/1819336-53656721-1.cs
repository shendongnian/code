    btnReverser.Click += OnBtnClick;
    private void OnBtnClick(object sender, ButtonEventArgs e)
    {
        var reverse = textbox1.Text.Reverse();
        label1.Text = reverse;
    }
