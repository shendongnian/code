    public class ValidatedTextBox : TextBox
        {
            private IContainer components;
            private Color m_OldBackColor;        
            [Description("Color to be set when validation fails.")]
            public Color BackColorOnFailedValidation
            {
                get
                {
                    return m_BackColorOnFailedValidation;
                }
    
                set
                {
                    m_BackColorOnFailedValidation = value;
                }
            }
            private Color m_BackColorOnFailedValidation = Color.Yellow;
    
            [Description("Message displayed by the error provider.")]
            public string ErrorMessage
            {
                get
                {
                    return m_ErrorMessage;
                }
    
                set
                {
                    m_ErrorMessage = value;
                }
            }
            private string m_ErrorMessage = "";
    
    
            [Description("Regular expression string to validate the text.")]
            public string RegularExpressionString
            {
                get
                {
                    return m_RegularExpressionString;
                }
                set
                {              
                    m_RegularExpressionString = value;
                }
            }
            private string m_RegularExpressionString = "";
            private ErrorProvider errorProvider1;
    
            [Browsable(false)]
            public bool Valid
            {
                get
                {
                    return m_Valid;
                }
            }
            private bool m_Valid = true;
    
            public ValidatedTextBox()
                : base()
            {
                InitializeComponent();
                m_OldBackColor = this.BackColor;
                this.Validating += new System.ComponentModel.CancelEventHandler(ValidatedTextBox_Validating);
                errorProvider1.Clear();
            }
    
            void ValidatedTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
            {
                if (RegularExpressionString != string.Empty)
                {
                    Regex regex = new Regex(RegularExpressionString);
                    m_Valid = regex.IsMatch(Text);
                    SetBackColor();
                    if (!Valid)
                    {
                        errorProvider1.SetError(this, this.ErrorMessage);
                        this.Focus();
                    }
                    else
                    {
                        errorProvider1.Clear();
                    }
                }
            }
    
            private void SetBackColor()
            {
                if (!Valid)
                    BackColor = BackColorOnFailedValidation;
                else
                    BackColor = m_OldBackColor;
            }
    
            private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
                ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
                this.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
                this.ResumeLayout(false);
    
            }
        }
