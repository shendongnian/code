        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations.Schema;
        using Microsoft.EntityFrameworkCore;
        namespace stackoverflow54196199
        {
        public class Team
        {
            public int Id { get; set; }
            public string Name { get; set; }
            [InverseProperty("HomeTeam")]
            public ICollection<Game> HomeGames { get; set; }
            [InverseProperty("AwayTeam")]
            public ICollection<Game> AwayGames { get; set; }
        }
        public class Game
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public int HomeTeamId { get; set; }
            [ForeignKey("HomeTeamId")]
            public Team HomeTeam { get; set; }
            public int AwayTeamId { get; set; }
            [ForeignKey("AwayTeamId")]
            public Team AwayTeam { get; set; }
        }
        public class MyContext : DbContext
        {
            public DbSet<Game> Games { get; set; }
            public DbSet<Team> Teams { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=.;Integrated Security=true;Initial Catalog=stackoverflow54196199;Persist Security Info=False;");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var db = new MyContext();
                foreach (var game in db.Games.Include(i => i.AwayTeam).Include(i => i.HomeTeam))
                {
                    Console.WriteLine(game.HomeTeam.Name);
                    Console.WriteLine(game.AwayTeam.Name);
                }
                Console.ReadLine();
            }
        }
        }
