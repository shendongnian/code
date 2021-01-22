    protected override System.Collections.ObjectModel.ReadOnlyCollection<System.IdentityModel.Policy.IAuthorizationPolicy> ValidateUserNamePasswordCore(string userName, string password)
            {           
                ClaimSet claimSet = new DefaultClaimSet(ClaimSet.System, new Claim(ClaimTypes.Name, userName, Rights.PossessProperty));
                List<IIdentity> identities = new List<IIdentity>(1);
                identities.Add(new MyIdentity(userName,password));
                List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>(1);
                policies.Add(new MyAuthorizationPolicy(ClaimSet.System, identities));
                return policies.AsReadOnly();
            }
    public class MyAuthorizationPolicy : IAuthorizationPolicy
        {
            String id = Guid.NewGuid().ToString();
            ClaimSet issuer;
            private IList<IIdentity> identities;
            #region IAuthorizationPolicy Members
    
    
            public MyAuthorizationPolicy(ClaimSet issuer, IList<IIdentity> identities)
            {
                if (issuer == null)
                    throw new ArgumentNullException("issuer");
                this.issuer = issuer;
                this.identities = identities;
                
            }
    
            public bool Evaluate(EvaluationContext evaluationContext, ref object state)
            {
                if (this.identities != null)
                {
                    object value;
                    IList<IIdentity> contextIdentities;
                    if (!evaluationContext.Properties.TryGetValue("Identities", out value))
                    {
                        contextIdentities = new List<IIdentity>(this.identities.Count);
                        evaluationContext.Properties.Add("Identities", contextIdentities);
                    }
                    else
                    {
                        contextIdentities = value as IList<IIdentity>;
                    }
                    foreach (IIdentity identity in this.identities)
                    {
                        contextIdentities.Add(identity);
                    }
                }
                return true;
            }
    
            public ClaimSet Issuer
            {
                get { return this.issuer; }
            }
    
            #endregion
    
            #region IAuthorizationComponent Members
    
            public string Id
            {
                get { return this.id; }
            }
    
            #endregion
        }
