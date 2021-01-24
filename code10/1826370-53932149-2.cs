    public struct PSU
    {
         public CheckBox CallHostessButton0, CallHostessButton1,
         ReadLightButton0, ReadLightButton1, ReadLightButton2, ReadLightButton3;
         public PictureBox BeltLight, SmokeLight;
     }
     public void AssignObjectsToPSU(UniversalVariables.PSU psu, CheckBox 
     CallHostessBtn0, EventHandler HBtn0CheckedChanged, CheckBox 
     CallHostessBtn1, EventHandler HBtn1CheckedChanged)
     {
     // and i'm trying to do this in my function:
     ...
     psu.CallHostessButton0 = CallHostessBtn0;
     psu.CallHostessButton0.CheckedChanged += new EventHandler(HBtn0CheckedChanged); 
     ...
     }
