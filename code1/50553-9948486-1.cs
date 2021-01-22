    using System.Windows.Forms;
    using System.Linq;
    public MyUserControlCtor()
    {
        InitializeComponent();
        foreach( Control ctrl in Controls)
        {
            ComboBox cb = ctrl as ComboBox;
            if (cb != null)
            {
                cb.Resize += (sender, e) =>
                {
                    if (!cb.Focused)
                        this.FCHZ_ComboBox.SelectionLength = 0;
                };
            }
        } 
    }
