    protected void btnSubmit_Click(object sender, EventArgs e)
            {
                recaptcha.Validate();
    
                if (recaptcha.IsValid)
                {
                    RecaptchaResult.Text = "Success";
    
                    RecaptchaResult.Text = "You got it!";
                    RecaptchaResult.ForeColor = System.Drawing.Color.Green;
                    RecaptchaResult.Visible = true;
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "recaptcha", "recaptcha.reload();", true);
                    UpdatePanel1.Update();
                }
                else
                {
                    RecaptchaResult.Text = this.recaptcha.ErrorMessage;
                    RecaptchaResult.ForeColor = System.Drawing.Color.Red;
                    RecaptchaResult.Visible = true;
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "recaptcha", "recaptcha.reload();", true);
                    UpdatePanel1.Update();
    
                }
                
            }
