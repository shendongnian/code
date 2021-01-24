    using System;
    using System.CodeDom;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.ComponentModel.Design.Serialization;
    using System.Drawing;
    using System.Windows.Forms;
    using ControlDesigner = System.Windows.Forms.Design.ControlDesigner;
    
    namespace WindowsFormsApp1
    {
        [DesignerSerializer(typeof(TestSerializer), typeof(CodeDomSerializer))]
        [Designer(typeof(TestEditor), typeof(IDesigner))]
        public partial class TestControl1 : UserControl
        {
            public TestControl1()
            {
                InitializeComponent();
            }
        }
    
        public class TestEditor : ControlDesigner
        {
            private static int _counter;
    
            public TestEditor()
            {
                Verbs.Add(new DesignerVerb("Add button", Handler));
            }
    
            private void Handler(object sender, EventArgs e)
            {
                var button = new Button
                             {
                                 Enabled = true,
                                 Text = "Hello",
                                 Name = string.Format("Button{0}", ++_counter)
                             };
                button.Location = new Point(0, _counter * button.Size.Height);
                ((TestControl1)Component).Controls.Add(button);
            }
        }
    
        public class TestSerializer : CodeDomSerializer
        {
            public override object Serialize(IDesignerSerializationManager manager, object value)
            {
                if (value.GetType() == typeof(TestControl1))
                {
                    var serializer = manager.GetSerializer(typeof(TestControl1).BaseType, typeof(CodeDomSerializer)) as CodeDomSerializer;
                    if (serializer != null)
                    {
                        var coll = serializer.Serialize(manager, value) as CodeStatementCollection;
                        if (coll != null)
                        {
                            var tc = (TestControl1)value;
                            foreach (Control control in tc.Controls)
                            {
                                coll.Insert(0, new CodeCommentStatement("Component " + control.Name));
                            }
                        }
    
                        return coll;
                    }
                }
    
                return base.Serialize(manager, value);
            }
        }
    }
