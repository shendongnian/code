    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    [XmlInclude(typeof(IncomeProfile))]
    [XmlInclude(typeof(CostProfile))]
    [XmlInclude(typeof(InvestmentProfile))]
    public class Profile {
        public string Foo { get; set; }
    }
    public class IncomeProfile : Profile {
        public int Bar { get; set; }
    }
    public class CostProfile : Profile { }
    public class InvestmentProfile : Profile { }
    static class Program {
        static void Main() {
            List<Profile> profiles = new List<Profile>();
            profiles.Add(new IncomeProfile { Foo = "abc", Bar = 123 });
            profiles.Add(new CostProfile { Foo = "abc" });
            new XmlSerializer(profiles.GetType()).Serialize(Console.Out, profiles);
        }
    }
