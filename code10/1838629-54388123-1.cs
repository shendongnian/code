    class PartDetail 
    {
     ....
     //create an instance of your SpecificDetails class
     SpecificDetails Details = new SpecificDetails();
     ...
     public PartDetail(string line) 
     {
      string[] parts = line.Split(',');
      this.Description = parts[0];
      this.BottomEdge = parts[1].Split(';'); 
      
      //assign the value to the properties of the "Details" instance
      this.Details.Sequence = this.BottomEdge[0];
      this.Details.Rotation = this.BottomEdge[1];
     }
    }
