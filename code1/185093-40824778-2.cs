    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    using System.Windows.Forms.Design.Behavior;
    
    namespace Utils.GUI
    {
        [Designer(typeof(InfoProgressBarDesigner))]
        public partial class InfoProgressBar : ProgressBar
        {
            // designer class to add font baseline snapline by copying it from the label
            private class InfoProgressBarDesigner : ControlDesigner
            {
                public override IList SnapLines
                {
                    get
                    {
                        IList snapLines = base.SnapLines;
    
                        InfoProgressBar control = Control as InfoProgressBar;
    
                        if(control != null)
                        {
                            using(IDesigner designer = TypeDescriptor.CreateDesigner(control.lblText, typeof(IDesigner)))
                            {
                                if(designer != null)
                                {
                                    designer.Initialize(control.lblText);
    
                                    ControlDesigner boxDesigner = designer as ControlDesigner;
    
                                    if(boxDesigner != null)
                                    {
                                        foreach(SnapLine line in boxDesigner.SnapLines)
                                        {
                                            if(line.SnapLineType == SnapLineType.Baseline)
                                            {
                                                snapLines.Add(new SnapLine(SnapLineType.Baseline, line.Offset, line.Filter, line.Priority));
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
    
                        return snapLines;
                    }
                }
            }
    
            // enum to select the type of displayed value
            public enum ProgressBarDisplayType
            {
                Custom = 0,
                Percent = 1,
                Progress = 2,
                Remain = 3,
                Value = 4,
            }
    
            private string _customText;
            private ProgressBarDisplayType _displayType;
            private int _range;
    
            [Bindable(false)]
            [Browsable(true)]
            [DefaultValue("{0}")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            // {0} is replaced with the result of the selected calculation
            public string CustomText
            {
                get
                {
                    return _customText;
                }
                set
                {
                    _customText = value;
                    UpdateText();
                }
            }
    
            [Bindable(false)]
            [Browsable(true)]
            [DefaultValue(ProgressBarDisplayType.Percent)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            public ProgressBarDisplayType DisplayType
            {
                get
                {
                    return _displayType;
                }
                set
                {
                    _displayType = value;
                    UpdateText();
                }
            }
    
            [Bindable(false)]
            [Browsable(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            // don't use the lblText font as if it is null, it checks the parent font (i.e. this property) and gives an infinite loop
            public override Font Font
            {
                get
                {
                    return base.Font;
                }
                set
                {
                    base.Font = value; 
                }
            }
    
            [Bindable(false)]
            [Browsable(true)]
            [DefaultValue(100)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            public new int Maximum
            {
                get
                {
                    return base.Maximum;
                }
                set
                {
                    base.Maximum = value;
                    _range = base.Maximum - base.Minimum;
                    UpdateText();
                }
            }
    
            [Bindable(false)]
            [Browsable(true)]
            [DefaultValue(0)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            public new int Minimum
            {
                get
                {
                    return base.Minimum;
                }
                set
                {
                    base.Minimum = value;
                    _range = base.Maximum - base.Minimum;
                    UpdateText();
                }
            }
    
            [Bindable(false)]
            [Browsable(true)]
            [DefaultValue(ContentAlignment.MiddleLeft)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            public ContentAlignment TextAlign 
            {
                get
                {
                    return lblText.TextAlign;
                }
                set
                {
                    lblText.TextAlign = value;
                }
            }
    
            [Bindable(false)]
            [Browsable(true)]
            [DefaultValue(typeof(Color), "0x000000")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            public Color TextColor
            {
                get
                {
                    return lblText.ForeColor;
                }
                set
                {
                    lblText.ForeColor = value;
                }
            }
    
            [Bindable(false)]
            [Browsable(true)]
            [DefaultValue(0)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            public new int Value
            {
                get
                {
                    return base.Value;
                }
                set
                {
                    base.Value = value;
                    UpdateText();
                }
            }
    
            public InfoProgressBar()
            {
                InitializeComponent();
    
                CustomText = "{0}";
                DisplayType = ProgressBarDisplayType.Percent;
                Maximum = 100;
                Minimum = 0;
                TextAlign = ContentAlignment.MiddleLeft;
                TextColor = Color.Black;
                Value = 0;
    
                // means the label gets drawn in front of the progress bar
                lblText.Parent = this;
    
                _range = base.Maximum - base.Minimum;
            }
    
            protected void UpdateText()
            {
                switch(DisplayType)
                {
                    case ProgressBarDisplayType.Custom:
                    {
                        lblText.Text = _customText;
                        break;
                    }
                    case ProgressBarDisplayType.Percent:
                    {
                        if(_range > 0)
                        {
                            lblText.Text = string.Format(_customText, string.Format("{0}%", (int)((Value * 100) / _range)));
                        }
                        else
                        {
                            lblText.Text = "100%";
                        }
                        break;
                    }
                    case ProgressBarDisplayType.Progress:
                    {
                        lblText.Text = string.Format(_customText, (Value - Minimum));
                        break;
                    }
                    case ProgressBarDisplayType.Remain:
                    {
                        lblText.Text = string.Format(_customText, (Maximum - Value));
                        break;
                    }
                    case ProgressBarDisplayType.Value:
                    {
                        lblText.Text = string.Format(_customText, Value);
                        break;
                    }
                }
            }
    
            public new void Increment(int value)
            {
                base.Increment(value);
                UpdateText();
            }
    
            public new void PerformStep()
            {
                base.PerformStep();
                UpdateText();
            }
        }
    }
