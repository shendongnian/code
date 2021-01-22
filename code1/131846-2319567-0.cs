    List<USBDevice> CompleteList = new List<USBDevice>();
    CompleteList.Add(new USBDevice(){VID = "10C4", Other = "x"});
    CompleteList.Add(new USBDevice() { VID = "10C4", Other = "x" });
    
    //..Fill CompleteList with all attached devices....
    
    List<USBDevice> SubSetList = new List<USBDevice>();
    SubSetList = CompleteList.Where(d => d.VID.Equals("10C4")).ToList();
