    public static void FocusFirst(this IEnumerable<IFormControl> formControls)
    {
        var focused = false;
        foreach(var formControl in formControls)
        {
            if(formControl.Focus())
            {
                break;
            }
        }
    }
