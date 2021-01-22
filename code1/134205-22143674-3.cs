    CaptchaControl1.ValidateCaptcha(txtcaptcha.Text.Trim());
         if (CaptchaControl1.UserValidated)
                    {
                        lbierror.ForeColor = System.Drawing.Color.Green;
                        lbierror.Text = "Valid";
                    }
                    else
                    {
                        lbierror.ForeColor = System.Drawing.Color.Red;
                        lbierror.Text = "InValid Captacha";
                    }
