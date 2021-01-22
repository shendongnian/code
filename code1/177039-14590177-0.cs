    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            int numGroupBoxes = 4;
            for (int groupBoxIndex=0; groupBoxIndex<numGroupBoxes; groupBoxIndex++ )
            {
                GroupBox groupBox = new GroupBox();
                groupBox.Text = "Group " + groupBoxIndex;
                groupBox.Size = new Size(this.Width, 0);
                groupBox.Dock = DockStyle.Top;
                this.Controls.Add(groupBox);
                FlowLayoutPanel groupBoxFlowLayout = new FlowLayoutPanel();
                groupBoxFlowLayout.Dock = DockStyle.Fill;
                groupBox.Controls.Add(groupBoxFlowLayout);
                int extraSpace = 25; // the difference in height between the groupbox and the contents inside of it
                MethodInvoker resizeGroupBox = (() =>
                {
                    int numControls = groupBoxFlowLayout.Controls.Count;
                    if ( numControls > 0 )
                    {
                        Control lastControl = groupBoxFlowLayout.Controls[numControls - 1];
                        int bottom = lastControl.Bounds.Bottom;
                        groupBox.Size = new Size(groupBox.Width, bottom + extraSpace);
                        groupBoxFlowLayout.Size = new Size(groupBoxFlowLayout.Width, bottom);
                    }
                });
                groupBoxFlowLayout.Resize += ((s, e) => resizeGroupBox());
                groupBoxFlowLayout.ControlAdded += ((s, e) => resizeGroupBox());
                    
                // Populate each flow panel with a different number of buttons
                int numButtonsInGroupBox = 3 * (groupBoxIndex+1);
                for (int buttonIndex = 0; buttonIndex < numButtonsInGroupBox; buttonIndex++)
                {
                    Button button = new Button();
                    button.Margin = new Padding(0, 0, 0, 0);
                    string buttonText = buttonIndex.ToString();
                    button.Text = buttonText;
                    button.Size = new Size(0,0);
                    button.AutoSize = true;
                    groupBoxFlowLayout.Controls.Add(button);
                }
            }
        }
    }
