    query {
        plane(id: "1"){
            id
            model
            callsign
            airportid
            pilot {
                edges {
                    node {
                    id
                    name
                    }
                }
            }
        }
    }
