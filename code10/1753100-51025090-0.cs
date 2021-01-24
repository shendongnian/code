    foreach ( var routes in document.Descendants("RoutePoints") ){
        foreach ( var points in routes.Elements() ) {
            if ( points.Attributes( i + "type").FirstOrDefault != null ){
                 if ( points.Attributes(i+"type").First().Value == "RoutePoint") {
                    //Processing..
                 }
                 if ( points.Attributes(i+"type").First().Value == "RoutePointTakeOff") {
                    //Processing..
                 }
                 if ( points.Attributes(i+"type").First().Value == "RoutePointLanding") {
                    //Processing..
                 }
            } else {
                 // Will execute this in rows 4-5    
            }
        }
    }
