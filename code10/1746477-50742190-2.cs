    public class Surface
    {
        /// <summary>
        /// Name of the surface e.g. RockA
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Moment magnitude Mw
        /// </summary>
        public double Moment { get; set; }
        /// <summary>
        /// Source to site distance from 0 to 20 km
        /// </summary>
        public int SourceToSite20 { get; set; }
        /// <summary>
        /// Source to site distance from 20 to 50 km
        /// </summary>
        public int SourceToSite50 { get; set; }
        /// <summary>
        /// Source to site distance from 50 to 100 km
        /// </summary>
        public int SourceToSite100 { get; set; }
    }
