    using System.ComponentModel;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace WebUtilities
    {
        [ToolboxData("<{0}:PriceInfo runat=server></{0}:PriceInfo>")]
        public class PriceInfo : WebControl, INamingContainer
        {
            private readonly Control ifDiscountControl = new Control();
            private readonly Control ifNotDiscountControl = new Control();
            public bool HasDiscount { get; set; }
            [PersistenceMode(PersistenceMode.InnerProperty)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public Control IfDiscount
            {
                get { return ifDiscountControl; }
            }
            [PersistenceMode(PersistenceMode.InnerProperty)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public Control IfNotDiscount
            {
                get { return ifNotDiscountControl; }
            }
            public override void RenderControl(HtmlTextWriter writer)
            {
                if (HasDiscount)
                    ifDiscountControl.RenderControl(writer);
                else
                    ifNotDiscountControl.RenderControl(writer);
            }
        }
    }
