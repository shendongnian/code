        private bool ignoreSelectionChanges = false;
        private void Selected_ID_Changed()
        {
            ignoreSelectionChanges = true;
            Find_Foos();
            Find_Bars();
            ignoreSelectionChanges = false;
            GetDataPoint();
        }
        private void Selected_Foo_Changed()
        {
            if (!ignoreSelectionChanges)
            {
                ignoreSelectionChanges = true;
                Find_Bars();
                ignoreSelectionChanges = false;
                GetDataPoint();
            }
        }
        private void Selected_Bar_Changed()
        {
            if (!ignoreSelectionChanges)
            {
                GetDataPoint();
            }
        }
