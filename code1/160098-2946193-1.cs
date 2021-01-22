    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class XboxStats
    {
        static void Main()
        {
            string uri = "http://xboxapi.duncanmackenzie.net/gamertag.ashx?GamerTag=Festive+Turkey";
            XDocument document = XDocument.Load(uri);
    
            var xboxInfo = document.Element("XboxInfo");
    
            var data = new
            {
                AccountStatus = (string)xboxInfo.Element("AccountStatus"),
                PresenceInfo = new
                {
                    Valid = (bool)xboxInfo.Element("PresenceInfo").Element("Valid"),
                    Info = (string)xboxInfo.Element("PresenceInfo").Element("Info"),
                    Info2 = (string)xboxInfo.Element("PresenceInfo").Element("Info2"),
                    LastSeen = (DateTime)xboxInfo.Element("PresenceInfo").Element("LastSeen"),
                    Online = (bool)xboxInfo.Element("PresenceInfo").Element("Online"),
                    StatusText = (string)xboxInfo.Element("PresenceInfo").Element("StatusText"),
                    Title = (string)xboxInfo.Element("PresenceInfo").Element("Title")
                },
                State = (string)xboxInfo.Element("State"),
                Gamertag = (string)xboxInfo.Element("Gamertag"),
                ProfileUrl = (string)xboxInfo.Element("ProfileUrl"),
                TileUrl = (string)xboxInfo.Element("TileUrl"),
                Country = (string)xboxInfo.Element("Country"),
                Reputation = (decimal)xboxInfo.Element("Reputation"),
                Bio = (string)xboxInfo.Element("Bio"),
                Location = (string)xboxInfo.Element("Location"),
                ReputationImageUrl = (string)xboxInfo.Element("ReputationImageUrl"),
                GamerScore = (int)xboxInfo.Element("GamerScore"),
                Zone = (string)xboxInfo.Element("Zone"),
                RecentGames = new
                {
                    XboxUserGameInfos = from gameInfo in xboxInfo.Element("RecentGames").Elements("XboxUserGameInfo")
                                        select new
                                        {
                                            Game = new
                                            {
                                                Name = (string)gameInfo.Element("Game").Element("Name"),
                                                TotalAchievements = (int)gameInfo.Element("Game").Element("TotalAchievements"),
                                                TotalGamerScore = (int)gameInfo.Element("Game").Element("TotalGamerScore"),
                                                Image32Url = (string)gameInfo.Element("Game").Element("Image32Url"),
                                                Image64Url = (string)gameInfo.Element("Game").Element("Image64Url")
                                            },
                                            LastPlayed = (DateTime)gameInfo.Element("LastPlayed"),
                                            Achievements = (int)gameInfo.Element("Achievements"),
                                            GamerScore = (int)gameInfo.Element("GamerScore"),
                                            DetailsUrl = (string)gameInfo.Element("DetailsUrl")
                                        }
    
                }
            };
    
            Console.WriteLine(data.AccountStatus);
    
            foreach (var gameInfo in data.RecentGames.XboxUserGameInfos)
            {
                Console.WriteLine(gameInfo.Game.Name);
            }
    
            Console.Read();
        }
    }
