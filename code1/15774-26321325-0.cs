    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms.Integration;
    using System.Windows.Forms.Design;
    [Designer(typeof(ControlDesigner))]
    class SpellCheckTextbox: ElementHost
    {
        private TextBox box;
        public SpellCheckTextbox()
        {
            box = new TextBox();
            base.Child = box;
            box.TextChanged += (sender, e) => OnTextChanged(EventArgs.Empty);
            box.SpellCheck.IsEnabled = true;
            box.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            this.Size = new System.Drawing.Size(100, 200);
        }
        public override string Text
        {
            get { return box.Text; }
            set { box.Text = value; }
        }
        [DefaultValue(true)]
        public bool Multiline
        {
            get { return box.AcceptsReturn; }
            set { box.AcceptsReturn = value; }
        }
        [DefaultValue(false)]
        public bool ScrollBars
        {
            get 
            {
                if (box.VerticalScrollBarVisibility == ScrollBarVisibility.Visible ||
                    box.HorizontalScrollBarVisibility == ScrollBarVisibility.Visible)
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            
            }
            set 
            {
                if (value)
                {
                    box.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
                    box.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                }
                else
                {
                    box.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                    box.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
                }
            
            }
        }
        [DefaultValue(false)]
        public bool WordWrap
        {
            get { return box.TextWrapping != TextWrapping.NoWrap; }
            set { box.TextWrapping = value ? TextWrapping.Wrap : TextWrapping.NoWrap; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new System.Windows.UIElement Child
        {
            get { return base.Child; }
            set { /* Do nothing to solve a problem with the serializer !! */ }
        }
    }
