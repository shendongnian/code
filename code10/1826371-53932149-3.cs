    //UniversalVariables.cs
    public class PSU
    {
        public CheckBox CallHostessButton0, CallHostessButton1,
            ReadLightButton0, ReadLightButton1, ReadLightButton2, ReadLightButton3;
        public PictureBox BeltLight, SmokeLight;
        public PSU(CheckBox CallHostBtn0, CheckBox CallHostBtn1, CheckBox ReadLightBtn0, CheckBox ReadLightBtn1,
            PictureBox BeltLght, PictureBox SmokeLght, [Optional] CheckBox ReadLightBtn2, [Optional] CheckBox ReadLightBtn3)
        {
            Log("[Info] Assigning objects to PSU unit...");
            CallHostessButton0 = CallHostBtn0;
            CallHostessButton1 = CallHostBtn1;
            ReadLightButton0 = ReadLightBtn0;
            ReadLightButton1 = ReadLightBtn1;
            if (CallHostessButton0 == null || CallHostessButton1 == null || ReadLightButton1 == null || ReadLightButton0 == null)
            {
                LogReport("[Failed]");
            }
            else { LogReport("[OK]"); }
            if (ReadLightBtn2 != null)
            {
                Log(String.Format("[Info] Extra {0} detected...", nameof(ReadLightBtn2)));
                this.ReadLightButton2 = ReadLightBtn2;
                LogReport("[OK]");
                   
                if(ReadLightBtn3 != null)
                {
                    Log(String.Format("[Info] Extra {0} detected...", nameof(ReadLightBtn3)));
                    this.ReadLightButton3 = ReadLightBtn3;
                    LogReport("[OK]");
                }
            }
            this.BeltLight = BeltLght; this.SmokeLight = SmokeLght;
        }
