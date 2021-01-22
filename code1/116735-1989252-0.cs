    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;
    
    class HeroParseException : ApplicationException
    {
        public HeroParseException(string message) : base(message) {}
    }
    
    class Spell
    {
        public string Name { get; set; }
        public Dictionary<string, SpellAttributes> SpellAttributesByRank { get; set; }
    }
    
    class SpellAttributes
    {
        public int ManaCost{ get; set; }
        public TimeSpan Cooldown { get; set; }
        public string Effects { get; set; }
    }
    
    class Program
    {
        static string NameOfHero = "Andromeda";
    
        static void Main()
        {
            XDocument doc = XDocument.Load("input.xml");
            var spells = doc.Descendants(NameOfHero).Elements().Select(hero => new Spell
            {
                Name = hero.Element("Name").Value,
                SpellAttributesByRank = hero.Element("Ranks").Elements().ToDictionary(
                rank => rank.Name.ToString(),
                rank => new SpellAttributes
                {
                    ManaCost = int.Parse(rank.Element("ManaCost").Value),
                    Cooldown = parseCooldown(rank.Element("Cooldown").Value),
                    Effects = rank.Element("Effects").Value
                })
            });
        }
    
        private static TimeSpan parseCooldown(string p)
        {
            Match match = Regex.Match(p, @"(\d+)( Seconds)?");
            if (!match.Success)
                throw new HeroParseException("Format for timespan not supported: " + p);
            int number = int.Parse(match.Groups[1].Value);
            return TimeSpan.FromSeconds(number);
        }
    }
