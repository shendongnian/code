    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace Test
    {
        public partial class TestForm : Form
        {
            // This is property
            bool ShowFirstGroupBox
            {
                get
                {
                    // We let user get our property from private variable
                    return _ShowFirstGroupBox;
                }
                set
                {
                    // When user change this property we do something based on that
                    switch(value)
                    {
                        case true:
                            groupBox1.Size = new Size(groupBox1.Width, FirstGroupBoxDefaultHeight);
                            break;
                        case false:
                            groupBox1.Size = new Size(groupBox1.Width, 55);
                            break;
                    }
    
                    _ShowFirstGroupBox = value;
                }
            }
            bool ShowSecondGroupBox
            {
                get
                {
                    return _ShowSecondGroupBox;
                }
                set
                {
                    switch (value)
                    {
                        case true:
                            groupBox2.Size = new Size(groupBox1.Width, FirstGroupBoxDefaultHeight);
                            break;
                        case false:
                            groupBox2.Size = new Size(groupBox1.Width, 55);
                            break;
                    }
    
                    _ShowSecondGroupBox = value;
                }
            }
    
            // We store our boxes current state ( TRUE = shown, FALSE = HIDDEN )
            bool _ShowFirstGroupBox = true;
            bool _ShowSecondGroupBox = true;
    
            // We store our default height for groupboxes
            int FirstGroupBoxDefaultHeight;
            int SecondGroupBoxDefaultHeight;
    
            public TestForm()
            {
                InitializeComponent();
    
                // Assigning default height of our groupboxes
                FirstGroupBoxDefaultHeight = groupBox1.Height;
                SecondGroupBoxDefaultHeight = groupBox2.Height;
            }
    
            private void button1_Click_1(object sender, EventArgs e)
            {
                ShowFirstGroupBox = !(_ShowFirstGroupBox); // This sets our property value to opposite of this boolean
            }
            private void button1_Click_1(object sender, EventArgs e)
            {
                ShowSecondGroupBox = !(_ShowSecondGroupBox); // This sets our property value to opposite of this boolean
            }
        }
    }
