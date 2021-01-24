       mapView.CommandClickedCommand = new Command(Map_ClickedCommand);
       public async void Map_ClickedCommand(object p1)
       {
            var position = p1 as Position; // not sure what the type of position is
            if (!ZoneOpen)
                return;
            ActiveZonePositions.Add(position);
            if (ActiveZonePositions.Count > 1)
            {
                ZonePolyLine.LineCoordinates = ActiveZonePositions;
            }
            var pin = new TKCustomMapPin
            {
                Position = new TK.CustomMap.Position(position.Latitude, position.Longitude),
                IsVisible = true,
                IsDraggable = true,
                ShowCallout = false,
            };
            _pins.Add(pin);
            await CreatePointAsync(position);
            PointCount++;
        };  
