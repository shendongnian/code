	protected void Approve_Click(object sender, EventArgs e)
			{
				foreach (ListViewItem item in listUsers.Items)
				{
					if ((item.FindControl("Approved") as CheckBox).Checked == true)
					{
						Label myLabel = (Label)item.FindControl("UserNameLabel");
						try
							{
								IQueryable<SUR> user = null;
								user = db.SURs.Where(m => !m.IsApproved && m.UserName == myLabel.Text);
								
								if(user != null)
								{									
									db.sp_SUA(user.FirstOrDefault().ID, SessionMgr.CurrentUserID.ToString(), "Manual");
									db.SaveChanges();
								}
								Response.Redirect(Request.RawUrl);
							}
						
						catch(Exception ex)
						{
							Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
						}
					}
				} 
			}
		
