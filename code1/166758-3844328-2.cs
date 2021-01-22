    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web.UI.WebControls;
    
    namespace TestWeb
    {
        public class Custom
        {
            public string FieldToBind { get; set; } // other fields
            public byte[] Blob { get; set; } // your blob
        }
    
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                var list = new List<Custom>();
                list.Add(new Custom { FieldToBind = "pure text", Blob = new UTF8Encoding().GetBytes("blob") });
                grid.DataSource = list;
                /*grid.RowDataBound += (rS, rE) =>
                {
                    if (rE.Row.RowType == DataControlRowType.DataRow)
                    {
                        // could also be bound by the server-side
                        //(rE.Row.FindControl("blob") as ITextControl).Text = new UTF8Encoding().GetString((rE.Row.DataItem as Custom).Blob);
                    }
                };*/
                grid.DataBind();
            }
        }
    }
