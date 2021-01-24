        // ...service...
        private void checkResponsability(ItemValueCallback itemValue)
        {
            _eventAggregator.GetEvent<ServerUpdatedEvent>().Publish(new PropertyValuePair((string)itemValue.ClientHandle,(string)itemValue.Value);
        }
        // ...view model or intermediate service...
        private void OnServerUpdate(PropertyValuePair data)
        {
            switch (data.Property)
            {
                case "Zone1_Temp": Zone1Temp = int.Parse(data.Value); break;
            }
        }
