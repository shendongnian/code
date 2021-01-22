    protected override void RenderItem(ListItemType itemType, int repeatIndex, RepeatInfo repeatInfo, HtmlTextWriter writer)
	{
		RadioButton radioButton = new RadioButton();
		radioButton.Page = this.Page;
		radioButton.GroupName = this.UniqueID;
		radioButton.ID = this.ClientID + "_" + repeatIndex.ToString();
		radioButton.Text = this.Items[repeatIndex].Text;			
		radioButton.Attributes["value"] = this.Items[repeatIndex].Value;
		radioButton.Checked = this.Items[repeatIndex].Selected;
		radioButton.TextAlign = this.TextAlign;
		radioButton.AutoPostBack = this.AutoPostBack;
		radioButton.TabIndex = this.TabIndex;
		radioButton.Enabled = this.Enabled;
		radioButton.CssClass = InnerCssClass;
		radioButton.Style.Add(HtmlTextWriterStyle.BackgroundColor, this.Items[repeatIndex].Text);
		radioButton.RenderControl(writer);
		// add new label
		Label radioLabel = new Label();
		radioLabel.Text = this.Items[repeatIndex].Text;
		radioLabel.CssClass = this.Items[repeatIndex].Text;
		radioLabel.AssociatedControlID = this.ClientID + "_" + repeatIndex.ToString();
		radioLabel.RenderControl(writer);
	}
