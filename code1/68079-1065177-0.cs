    interface I3d
    {
        double Thickness {get; set;}
        double Width {get; set;}
        double Length {get; set;}
        double GetVolume
    }
    
    
    public class ThreeDimensionalShape : I3d
    {
      public double Thickness {get; set;}
      public double Width {get; set;}
      public double Length {get; set;}
      public double GetVolume()
      {
          return this.Thickness * this.Width * this.Length;
      }
    }
    
    class Member : ThreeDimensionalShape
    {
        public string Label {get;set;}
        // Lots of other fields...
    
        // Other methods
    }
    
    class OtherMember : ThreeDimensionalShape
    {
        public string CompositeLabel {get;set;}
        // Lots of other fields (not related to other class: Member)
    
        // Other methods
    }
