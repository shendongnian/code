                int numlabels = System.Convert.ToInt32(ddlNumOfVolunteers.SelectedItem.Text);
                for (int i = 1; i <= numlabels; i++)
                {
                    Label myLabel = new Label();
                    TextBox txtbox = new TextBox();
                    // Set the label's Text and ID properties.
                    myLabel.ID = "LabelVol" + i.ToString();
                    myLabel.Text = "Volunteer " + i.ToString();
                    txtbox.ID = "TxtBoxVol" + i.ToString();
                    PlaceHolder1.Controls.Add(myLabel);
                    PlaceHolder2.Controls.Add(txtbox);
                    // Add a spacer in the form of an HTML <br /> element.
                    PlaceHolder2.Controls.Add(new LiteralControl("<br />"));
                    PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
