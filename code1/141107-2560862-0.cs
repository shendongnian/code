        public void Execute(IPluginExecutionContext context)
        {
            if (context.InputParameters.Properties.Contains("Target") &&
                context.InputParameters.Properties["Target"] is DynamicEntity)
            {
                DynamicEntity opp = (DynamicEntity)context.InputParameters["Target"];
                Picklist StageCodePicklist = new Picklist(); (Picklist);opp.Properties["salesstagecode"];
                StageCodePicklist.name = "Advocating - Advanced (90%)";
                StageCodePicklist.Value = 200004;
                opp.Properties["salesstagecode"] = StageCodePicklist;
            }
        }
