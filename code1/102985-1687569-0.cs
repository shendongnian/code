     public void OnAddInsUpdate(AddInsUpdateEventArgs e)  { } 
    
     public class AddInsUpdateEventArgs : EventArgs 
     { 
        public int x { get; }  // Readonly for event handler
        public int? y { get; set; }  // Read/Write (eg if you can accept values back) 
        public bool? Handled { get; set; } 
     } 
