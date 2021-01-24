    protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
    {
        MemberService.Saved += MemberService_Saved;
    }
    
    void MemberService_Saved(IMemberService sender, Umbraco.Core.Events.SaveEventArgs<IMember> e)
    {
        foreach (var member in e.SavedEntities)
        {
            if (!member.IsNewEntity())
            {
                if (member.IsApproved && !member.GetValue<bool>("approvalEmailSent"))
                {
                    member.SetValue("approvalEmailSent", true);
                            
                    var dirtyProperties = member.Properties.Where(x => x.WasDirty()).Select(p => p.Alias);
                    if (dirtyProperties.Contains("umbracoMemberApproved"))
                    {
                        //Email Customer
                        //new SmtpClient().Send(mail);
                                
                        sender.Save(member, false);
                    }
                }
            }
        }
    }
