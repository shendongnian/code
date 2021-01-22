    class BaseMember
    {
        public string Label { get; set; }
        public double Thickness { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double GetVolume()
        {
            return Thickness * Width * Length;
        }
    }
    
    class Member : BaseMember
    { 
        // Things specific to Member
    }
    
    class OtherMember : BaseMember
    {
        // Things specific to OtherMember
    }
