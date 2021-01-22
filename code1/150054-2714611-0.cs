                    SuggestionList.TopLevel = false;
                    SuggestionList.Visible = true;
                    SuggestionList.Top = (this.Top + this.Height);
                    SuggestionList.Left = this.Left;
                    this.Parent.Controls.Add(SuggestionList);
                    SuggestionList.BringToFront();
