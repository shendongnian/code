     methC myData { get; set; }
     public BlankPage1()
     {
         // Microsoft mentioned that it can send basic types so we can serialize it at the sending time and deserialize it at using.
         myData = JsonConvert.DeserializeObject<methC>(GetNavigationState());
         
         Labelx.Text = myData.x;
         , ....
     }
