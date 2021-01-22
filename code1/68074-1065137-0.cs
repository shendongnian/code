    class Dimensions
    {
        public double Thickness {get;set;}
        public double Width {get;set;}
        public double Length {get;set;}
        public double GetVolume ()
        {
            return Thickness * Width * Length;
        }
    }
    class Member
    {
        public string Label {get;set;}
        // Lots of other fields...
        public Dimensions Dimensions {get;set;}
        // Other methods
    }
    class OtherMember
    {
        public string CompositeLabel {get;set;}
        // Lots of other fields (not related to other class: Member)
        public Dimensions Dimensions {get;set;}
        // Other methods
    }
