        private Expression<Func<CostStore,Decimal>> GetProjection()
        {
            switch (Session[Constants.FORMSESSIONKEY].ToString())
            {
                case Constants.NEWAPP: 
                    return c => c.InternalNew;
                case Constants.LOST:
                    return c=> c.InternalLost;
                // ... etc, you get the idea
                default:
                    return c => 0m; // or some other sensible default
                   // break;
            }
        }
