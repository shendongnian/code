    public static void SetControlThreadSafe(Control control, Action<object[]> action, object[] args)
    {
          if (control.InvokeRequired)
                try { control.Invoke(new Action<Control, Action<object[]>, object[]>(SetControlThreadSafe), control, action, args); } catch { }
          else action(args);
    }
