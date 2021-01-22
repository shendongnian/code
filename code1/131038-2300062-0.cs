        IIdentity GetClientIdentity(EvaluationContext evaluationContext)
        {
            object obj;
            if (!evaluationContext.Properties.TryGetValue("Identities", out obj))
                throw new Exception("No Identity found");
               IList<IIdentity> identities = obj as IList<IIdentity>;
               if (identities == null || identities.Count <= 0)
                  throw new Exception("No Identity found");
               return identities[0];
           }
