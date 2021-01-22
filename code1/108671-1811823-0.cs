    using System.Collections;
    using System.ComponentModel;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace Foo
    {
        [ToolboxData("<{0}:DDL runat=\"server\" />")]
        public class DDL : DropDownList
        {
    
            [Category("Data"), DefaultValue("")]
            public string DataToolTipField
            {
                get { return (string)(ViewState["DataToolTipField"] ?? string.Empty); }
                set { ViewState["DataToolTipField"] = value; }
            }
    
            protected override void PerformDataBinding(IEnumerable dataSource)
            {
                base.PerformDataBinding(dataSource);
    
                string dataToolTipField = this.DataToolTipField;
    
                if (!string.IsNullOrEmpty(dataToolTipField))
                {
                    IEnumerator enumerator = dataSource.GetEnumerator();
                    for (int i = 0; enumerator.MoveNext(); i++)
                    {
                        this.Items[i].Attributes.Add("title", (string)DataBinder.GetPropertyValue(enumerator.Current, dataToolTipField));
                    }
                }
            }
    
        }
    }
