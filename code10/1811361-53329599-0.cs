    using System;
    using System.Linq;
    using System.Reflection;
    /// <summary>
    /// Attribute to indicate the name mapped to a <see cref="Sponsor"/> subclass.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class SponsorAttribute : Attribute
    {
        public SponsorAttribute(string name)
        {
            this.Name = name;
        }
        /// <summary>
        /// The value that <see cref="SponserInfo.SponserName"/> must match for the attribute class to be used.
        /// </summary>
        public virtual string Name { get; set; }
    }
    public abstract class Sponsor
    {
        public int ReferenceId { get; set; }
        public string Password { get; set; }
    }
    [Sponsor("Sponser A's Name")]
    public class SponsorA : Sponsor
    {
    }
    [Sponsor("Sponser B's Name")]
    public class SponsorB : Sponsor
    {
        public string Department { get; set; }
    }
    // More subclasses can be added.
    public class SponsorInfo
    {
        /// <summary>
        /// The Sponsor name.
        /// Changing this sets <see cref="Sponsor"/> to a new instance of the corresponding class.
        /// </summary>
        public string SponsorName
        {
            get { return _sponsorName; }
            set
            {
                if (_sponsorName != value)
                {
                    _sponsorName = value;
                    // Find a Sponsor subclass with a SponsorAttribute.Name matching the given value:
                    Type sponsorType = Assembly.GetExecutingAssembly().GetTypes()   // you might want to also scan other assemblies
                        .Where(t =>
                            t.IsSubclassOf(typeof(Sponsor))
                            && (t.GetCustomAttribute<SponsorAttribute>()?.Name?.Equals(_sponsorName) ?? false)
                        ).FirstOrDefault();   // null if none is found
                    if (sponsorType == null)
                        Sponsor = null;     // no matching class
                    else
                        Sponsor = (Sponsor)Activator.CreateInstance(sponsorType);  // new instance of the matching class
                }
            }
        }
        private string _sponsorName;
        public Sponsor Sponsor { get; set; }   // renamed from "SponsorInfo" because that's the name of this class
    }
