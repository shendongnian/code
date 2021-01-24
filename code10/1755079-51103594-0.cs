    private void OnMsgBoxClick(object arg)
    {
        if (arg != null && arg.GetType() == typeof(int))
        {
            this.LogWarning("OnMsgBoxClick() arg: {0}", arg.ToString());
        }
    }
