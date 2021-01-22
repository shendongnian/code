        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            IIdentity identity = GetClientIdentity(evaluationContext);
            if (identity == null)
                throw new Exception();
            
                // These are my custom Identity and Principal classes
                Identity customIdentity = new Identity();
                Principal customPrincipal = new Principal(customIdentity);
                evaluationContext.Properties["Principal"] = customPrincipal;
                return true;
            }
