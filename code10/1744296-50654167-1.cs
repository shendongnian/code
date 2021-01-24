    var flight = Flighting.Flight.FromJson(yourjson);
                
             string currency   =   flight.Currency;
                var restrictions = flight.Results[0].Fare.Restrictions;
                var totalprice = flight.Results[0].Fare.TotalPrice;
                var adult = flight.Results[0].Fare.PricePerAdult;
                var a = flight.Results[0].Itineraries[0].Inbound.Flights[0].Aircraft;
                var bookingInfo = flight.Results[0].Itineraries[0].Inbound.Flights[0].BookingInfo;
                var d = flight.Results[0].Itineraries[0].Inbound.Flights[0].DepartsAt;
                var f = flight.Results[0].Itineraries[0].Inbound.Flights[0].FlightNumber;
                var op = flight.Results[0].Itineraries[0].Inbound.Flights[0].OperatingAirline;
