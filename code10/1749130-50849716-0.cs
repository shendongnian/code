        public void ModifyItem(ITelemetry item)
        {
            // Replace ikey
            item.Context.InstrumentationKey = this.ikey;
        }
