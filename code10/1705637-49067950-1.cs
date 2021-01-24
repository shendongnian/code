    using Basket.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    namespace Basket.Web.Models
    {
        public class PlayerIndex1Model
        {
            public int Id { get; set; }
            public List<Player> Players { get; set; }
            public string PlayerName { get; set; }
            public int PlayerWeight { get; set; }
            public string PlayerSurname { get; set; }
            public DateTime Birthday { get; set; }
            public string PlayerPosition { get; set; }
            public decimal PlayerHeight { get; set; }
            public string ClubName { get; set; }
            //fk
            [ForeignKey("BasketBallClub")]
            public int BasketBallClubId { get; set; }
            public virtual BasketBallClub BasketBallClub
            {
                get; set;
            }
        }
    }
