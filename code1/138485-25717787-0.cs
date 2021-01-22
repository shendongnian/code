    /*
    Here is fully functional class. Hope this will help someone
    For queries, contact amjad@qatar.net.qa
    */
    
    using System;
    using System.Data;
    using System.Configuration;
    using System.IO;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    
    
    public class GridViewExportUtil
    {
    
        public static void Export(string fileName, GridView gv)
        {
            HttpContext.Current.Response.Clear();
            //HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            //HttpContext.Current.Response.ContentType = "text/html; charset=utf-8";
    
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName + ".xls"));
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Unicode;
            HttpContext.Current.Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("iso-8859-2");
    
    
            //This will allow you to set the Report Header and Report Title
            //My file name format "ReportTitle_PatientID_PrescriptionNo_ReportDateTime"
            string [] arrFileName = fileName.Replace(".xls","").Split('_');
            string rptTitle = arrFileName[0] + " " + arrFileName[1];
            string rptPatientID = arrFileName[2];
            string rptSpecimen = arrFileName[3];
            string rptDate = arrFileName[4] + " " + arrFileName[5];
    
            /*Optional Header*/
            //HttpContext.Current.Response.Write("DEPARTMENT OF PHARMACY - Pharmacy Prescription Details<br>");
            //HttpContext.Current.Response.Write("Patient ID: " + rptPatientID + "<br>");
            //HttpContext.Current.Response.Write("Prescription No: " + rptSpecimen + "<br>");
            //HttpContext.Current.Response.Write("Report Date: " + rptDate);
            //HttpContext.Current.Response.Write("<br><br>");
    
    
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    //  Create a form to contain the grid
                    Table table = new Table();
    
                    //  add the header row to the table
                    if (gv.HeaderRow != null)
                    {
                        GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                        table.Rows.Add(gv.HeaderRow);
                    }
    
                    //  add each of the data rows to the table
                    foreach (GridViewRow row in gv.Rows)
                    {
                        GridViewExportUtil.PrepareControlForExport(row);
                        table.Rows.Add(row);
                    }
    
                    //  add the footer row to the table
                    if (gv.FooterRow != null)
                    {
                        GridViewExportUtil.PrepareControlForExport(gv.FooterRow);
                        table.Rows.Add(gv.FooterRow);
                    }
    
                    //  render the table into the htmlwriter
                    table.RenderControl(htw);
    
                }
    
                //  render the htmlwriter into the response
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
    
    
        }
    
        /// <summary>
        /// Replace any of the contained controls with literals
        /// </summary>
        /// <param name="control"></param>
        private static void PrepareControlForExport(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                Control current = control.Controls[i];
                if (current is LinkButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
                }
                else if (current is ImageButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
                }
                else if (current is HyperLink)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
                }
                else if (current is DropDownList)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
                }
                else if (current is CheckBox)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
                }
                if (current.HasControls())
                {
                    GridViewExportUtil.PrepareControlForExport(current);
                }
            }
        }
    }
    
