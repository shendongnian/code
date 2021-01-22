    public event EventHandler CheckedChanged
    {
        add {
             radioButton2.CheckedChanged += value;
            }
        remove {
             radioButton2.CheckedChanged -= value;
            }
    }
