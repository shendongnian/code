    using System;
   
    namespace test_radio_buttons
    {
        class ClearableRadioButton : System.Windows.Forms.RadioButton
        {
            private bool _checkedChanged = false;
            protected override void OnClick(EventArgs e)
            {
                base.OnClick(e);
                if (_checkedChanged)
                    _checkedChanged = false;
                else
                    base.Checked = false;
            }
            protected override void OnCheckedChanged(EventArgs e)
            {
                base.OnCheckedChanged(e);
                _checkedChanged = true;
            }
        }
    }
