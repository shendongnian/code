    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    [Designer(typeof(RichTextBoxExDesigner))]
    public class RichTextBoxEx : RichTextBox
    {
        public RichTextBoxEx ()
        {
            Text = "Some Text";
        }
    }
    public class RichTextBoxExDesigner : ControlDesigner
    {
        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
        {
            var txt = Control.Text;
            base.InitializeNewComponent(defaultValues);
            Control.Text = txt;
        }
    }
