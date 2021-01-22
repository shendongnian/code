public class RepeatingRuleTemplate : ITemplate
    {
        ListItemType templateType;
        List<Control> innerControls;
        public RepeatingRuleTemplate(ListItemType type, List<Control> controls)
        {
            templateType = type;
            innerControls = controls;
        }
        public void InstantiateIn(Control container)
        {
            PlaceHolder ph = new PlaceHolder();
            switch (templateType)
            {
                case ListItemType.Header:
                    ph.Controls.Add(new LiteralControl("<table border=\"0\">"));
                    ph.Controls.Add(new LiteralControl("<tr>"));
                    foreach (Control control in innerControls)
                    {
                        Label label = new Label();
                        label.Text = control.ID;
                        ph.Controls.Add(new LiteralControl("<td>"));
                        ph.Controls.Add(label);
                        ph.Controls.Add(new LiteralControl("</td>"));
                    }
                    ph.Controls.Add(new LiteralControl("</tr>"));
                    break;
                case ListItemType.Item:
                    ph.Controls.Add(new LiteralControl("<tr>"));
                    foreach (Control control in innerControls)
                    {
                            //ph.Controls.Add(new LiteralControl("<td>"));
                            //ph.Controls.Add(control as TextBox);
                            //ph.Controls.Add(new LiteralControl("</td>"));
                        if (control.GetType() != typeof(Repeater))
                        {
                            ph.Controls.Add(new LiteralControl("<td>"));
                            TextBox textBox = new TextBox();
                            textBox.ID = control.ID;
                            ph.Controls.Add(textBox);
                            ph.Controls.Add(new LiteralControl("</td>"));
                        }
                        else
                        {
                            ph.Controls.Add(new LiteralControl("<td>"));
                            Repeater rpt = new Repeater();
                            rpt.DataSource = (control as Repeater).DataSource;
                            rpt.ItemTemplate = (control as Repeater).ItemTemplate;
                            rpt.HeaderTemplate = (control as Repeater).HeaderTemplate;
                            rpt.FooterTemplate = (control as Repeater).FooterTemplate;
                            rpt.DataBind();
                            ph.Controls.Add(rpt);
                            //(control as Repeater).DataSource = new DataRow[4];
                            //   (control as Repeater).DataBind();
                            ph.Controls.Add(new LiteralControl("</td>"));
                        }
                    }
                    ph.Controls.Add(new LiteralControl("</tr>"));
                    //ph.DataBinding += new EventHandler(Item_DataBinding);
                    break;
                case ListItemType.Footer:
                    ph.Controls.Add(new LiteralControl("</table>"));
                    break;
            }
            container.Controls.Add(ph);
        }
       
        public List<Control> Controls
        {
            get
            {
                return innerControls;
            }
        }
    }
