    private void cmdOK_Click(object sender, EventArgs e)
    {
        dynamic option = bsOptions.Current;
        if (option.Id == 1) { doSomething(); }
          else { doSomethingElse(); }
    }
