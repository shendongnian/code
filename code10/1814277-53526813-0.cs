        private void addEvent(Int32 source)
        {
            Event a = new Event();
            a.Source_Id = source;
            a.Source_Name = "Device_" + source.ToString();
            a.Event_DateTime = DateTime.Now;
            this.Alarms.Add(a);
            CollectionViewSource.GetDefaultView(testdg.ItemsSource).Refresh();
        }
