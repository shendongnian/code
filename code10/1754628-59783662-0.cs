        var objclsPlayers = new List<Models.clsPlayers>();
            objclsPlayers.Add(new Models.clsPlayers
            {
                strId = 1,
                strGrade = "E",
                strRole = "Bat",
                strPlayerName = "Virat",
                strPosition = "One Down"
            });
            objclsPlayers.Add(new Models.clsPlayers
            {
                strId = 2,
                strGrade = "E",
                strRole = "Bat",
                strPlayerName = "Rohit",
                strPosition = "Opening"
            });
            objclsPlayers.Add(new Models.clsPlayers
            {
                strId = 3,
                strGrade = "E",
                strRole = "Bat",
                strPlayerName = "Rahul",
                strPosition = "Opening"
            });
            objclsPlayers.Add(new Models.clsPlayers
            {
                strId = 4,
                strGrade = "E",
                strRole = "Ball",
                strPlayerName = "Kuldip",
                strPosition = "Spinner"
            });
            objclsPlayers.Add(new Models.clsPlayers
            {
                strId = 5,
                strGrade = "E",
                strRole = "Ball",
                strPlayerName = "Kumar",
                strPosition = "Fast"
            });
            var objclsPositions = new List<Models.clsPositions>();
            objclsPositions.Add(new Models.clsPositions
            {
                strGrade = "A",
                strRole = "Bat",
                strPosition = "One Down"
            });
            objclsPositions.Add(new Models.clsPositions
            {
                strGrade = "B",
                strRole = "Bat",
                strPosition = "Opening"
            });
            objclsPositions.Add(new Models.clsPositions
            {
                strGrade = "C",
                strRole = "Ball",
                strPosition = "Spinner"
            });
            objclsPositions.Add(new Models.clsPositions
            {
                strGrade = "D",
                strRole = "Ball",
                strPosition = "Fast"
            });
            foreach (var NewData in objclsPlayers.Join(objclsPositions,
             Players => Players.strPosition, Positions => Positions.strPosition, 
             (Players, Positions) => new { Players, Positions })
             .Where(combine => { return combine.Players.strRole == combine.Positions.strRole; }))
            {
                NewData.Players.strGrade = NewData.Positions.strGrade;
            } 
