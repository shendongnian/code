    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.ComponentModel.Design;
    using System.Windows.Forms;
    using System.Drawing.Design;
    using System.Windows.Forms.Design;
    using System.Collections;
    using System.ComponentModel;
    
    namespace ppgExpandableList
    {
        public class ExpandableListEditor : CollectionEditor
        {
            public ExpandableListEditor(Type type) : base(type){}
            public override object EditValue(ITypeDescriptorContext context,
                System.IServiceProvider provider, object value)
            {
                object editedValue = base.EditValue(context, provider, value);
    
                IList tmpList = (IList)editedValue;
                object tmpValue = Activator.CreateInstance(value.GetType());
                IList editedList = (IList)tmpValue;
    
                foreach (object item in tmpList)
                {
                    editedList.Add(item);
                }
    
                return editedList;
            }
    
            public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            {
                return UITypeEditorEditStyle.Modal;
            }
        }
    }
