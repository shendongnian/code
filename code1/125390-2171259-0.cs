    class Archetype
    {
        string Name;
        Dictionary<string,Type> Properties;
        Dictionary<string,Action> Skills;
    }
    class Character
    {
        string Name;
        string Alias;
        Dictionary<Archetype,Dictionary<string,object>> FacetData;
    }
    class TheGame
    {
        public static void Main()
        {
            var Pilot = new Archetype();
            Pilot.Name = "Combat-Pilot";
            Pilot.Properties.Add("FlightHours", typeof(int));
            Pilot.Properties.Add("AmbientTypes", typeof(List<string>));
            var Jedi = new Archetype();
            Jedi.Name = "Jedi";
            Jedi.Properties.Add("ForceLevel", typeof(int));
            Jedi.Properties.Add("Title", typeof(string));
            Jedi.Properties.Add("IsCombatVeteran", typeof(bool));
            Jedi.Skills.Add("LightSaberFight", FightWithLightSaber());
            var Anakin = new Character();
            Anakin.Id = 100;
            Anakin.Name = "Anakin Skywalker";
            Anakin.Alias = "Darth Vader";
            Anakin.FacetData.Add(Pilot, new Dictionary<string, object>()
                { { "FlightHours", 2500 },
                  { "AmbientTypes", new List<string>() {"Atmospheric", "Space", "Hyper-Space"} } };
            Anakin.FacetData.Add(Jedi, new Dictionary<string, object>()
                { { "ForceLevel", 7 },
                  { "Title", "Padawan" },
                  { "IsCombatVeteran", true } };
            Anakin.ApplySkill(Jedi, "LightSaberFight", Target);
        }
        public static void FightWithLightSaber(Character Target)
        {
            ShowBrightLightSaberPointingTo(Target);
            EmitCoolSound();
        }
    }
