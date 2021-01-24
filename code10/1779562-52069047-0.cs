            switch (e.Key)
            {
                case Key.Escape:
                    this.DialogResult = false;
                    break;
                case Key.Return:
                    this.DialogResult = true;
                    break;
                case Key.Back:
                    if (ResultValue != null && ResultValue.Length > 0)
                        ResultValue = ResultValue.Remove(ResultValue.Length - 1);
                    if (isUserAccess)
                    {
                        if (UserAccessPasswordValue != null && UserAccessPasswordValue.Length > 0)
                            UserAccessPasswordValue = UserAccessPasswordValue.Remove(UserAccessPasswordValue.Length - 1);
                    }
                    break;
                case Key.Space:
                    if (!CheckOutputLength(ResultValue)) return;
                    ResultValue += " ";
                    break;
                case default :
                    CheckandAddValue(e.Key.ToString());
                    break;
            }
