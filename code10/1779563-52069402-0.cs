    switch (e.Key)
    {
        case Key.Escape:
            this.DialogResult = false;
            break;
        case Key.Return:
            this.DialogResult = true;
            break;
        case Key.Back:
            if (!string.IsNullOrEmpty(ResultValue))
                ResultValue = ResultValue.Remove(ResultValue.Length - 1);
            if (isUserAccess)
            {
                if (!string.IsNullOrEmpty(UserAccessPasswordValue))
                    UserAccessPasswordValue = UserAccessPasswordValue.Remove(UserAccessPasswordValue.Length - 1);
            }
            break;
        case Key.Space:
            if (!CheckOutputLength(ResultValue)) return;
            ResultValue += " ";
            break;
        case var k when k >= Key.D0 && k <= Key.NumPad9
                   && !(k >= Key.LWin && k <= Key.Sleep):
            CheckandAddValue(e.Key.ToString());
            break;
    }
