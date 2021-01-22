    using System;
    using System.Linq;
    using System.Windows.Forms;
    namespace MyApp.GUI
    {
        public class FilteredTextBox : TextBox
        {
            // Fields
            private char[] m_validCharacters;
            private string m_filter;
            private event EventHandler m_maxLength;
            // Properties
            public string Filter
            {
                get
                {
                    return m_filter;
                }
                set
                {
                    m_filter = value;
                    m_validCharacters = value.ToCharArray();
                }
            }
            // Constructor
            public FilteredTextBox()
            {
                m_filter = "";
                this.KeyPress += Validate_Char_OnKeyPress;
                this.TextChanged += Check_Text_Length_OnTextChanged;
            }
            // Event Hooks
            public event EventHandler TextBoxFull
            {
                add { m_maxLength += value; }
                remove { m_maxLength -= value; }
            }
            // Methods
            void Validate_Char_OnKeyPress(object sender, KeyPressEventArgs e)
            {
                if (m_validCharacters.Contains(e.KeyChar) || e.KeyChar == '\b')
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            void Check_Text_Length_OnTextChanged(object sender, EventArgs e)
            {
                if (this.TextLength == this.MaxLength)
                {
                    var Handle = m_maxLength;
                    if (Handle != null)
                        Handle(this, EventArgs.Empty);
                }
            }
        }
    }
