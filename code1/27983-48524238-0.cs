    [HttpPost]
    public ActionResult ConfirmMobile(string nameValueResend, string nameValueSubmit, RegisterModel model)
        {
			var button = nameValueResend ?? nameValueSubmit;
			if (button == "Resend")
			{
				
			}
			else
			{
				
			}
		}
		
		
		Razor file Content:
		@using (Html.BeginForm()
		{
			<div class="page registration-result-page">
				 
				<div class="page-title">
					<h1> Confirm Mobile Number</h1>
				</div>
			 
				<div class="result">
					@Html.EditorFor(model => model.VefificationCode)
					@Html.LabelFor(model => model.VefificationCode, new { })
					@Html.ValidationMessageFor(model => model.VefificationCode)
				</div>
				<div class="buttons">
					<button type="submit" class="btn" name="nameValueResend" value="Resend">
						Resend
					</button>
					<button type="submit" class="btn" name="nameValueSubmit" value="Verify">
						Submit
					</button>
				</div>
				</div>
			 
		}
