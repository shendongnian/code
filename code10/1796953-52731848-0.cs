     methC myData { get; set; }
     public BlankPage1()
     {
         // Microsoft mentioned that it does serialize your object on sending so you must deserialize it before using.
         myData = JsonConvert.DeserializeObject<methC>(GetNavigationState());
         
         Labelx.Text = myData.x;
         , ....
     }
