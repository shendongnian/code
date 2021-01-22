    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WinFormsTest
    {
        public partial class MaskedTextBox : TextBox
        {
            public enum EntryTypeEnum
            {
                Any,
                Integer,
                Decimal
            }
    
            [DefaultValue(EntryTypeEnum.Any)]
            public EntryTypeEnum EntryType { get; set; }
            
            public MaskedTextBox()
            {
                InitializeComponent();
            }
    
            protected override void OnKeyPress(KeyPressEventArgs e)
            {
                var keyIsValid =
                    (EntryType == EntryTypeEnum.Any)
                    || char.IsControl(e.KeyChar)
                    || isValid(Text + e.KeyChar);
                e.Handled = !keyIsValid;
                base.OnKeyPress(e);
            }
    
            protected override void OnValidating(CancelEventArgs e)
            {
                e.Cancel = !isValid(Text);
                base.OnValidating(e);
            }
    
            protected bool isValid(string textToValidate)
            {
                switch (EntryType)
                {
                    case EntryTypeEnum.Any:
                        break;
    
                    case EntryTypeEnum.Decimal:
                        {
                            decimal result;
                            if (!decimal.TryParse(textToValidate, out result))
                            {
                                return false;
                            }
                        }
                        break;
    
                    case EntryTypeEnum.Integer:
                        {
                            int result;
                            if (!int.TryParse(textToValidate, out result))
                            {
                                return false;
                            }
                        }
                        break;
                }
    
                return true;
            }
        }
    }
