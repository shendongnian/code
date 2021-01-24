    public static class MidiNote
    {
        public static MidiOut MidiOut = new MidiOut(0);
        public static void PlayNote(int key, int duration)
        {
            MidiOut.Volume = 65535;
            MidiOut.Send(MidiMessage.StartNote(key, 127, 1).RawData);
            Thread.Sleep(duration);
            MidiOut.Send(MidiMessage.StopNote(key, 0, 1).RawData);
        }
        public static void SetPanHardLeft()
        {
            var panSettingHardLeft = 0;
            var cce = new ControlChangeEvent(0L, 1, MidiController.Pan, panSettingHardLeft);
            MidiOut.Send( cce.GetAsShortMessage() );
        }
        public static void SetPanHardRight()
        {
            var panSettingHardRight = 127;
            var cce = new ControlChangeEvent(0L, 1, MidiController.Pan, panSettingHardRight);
            MidiOut.Send(cce.GetAsShortMessage());
        }
        public static void SetPanCenter()
        {
            var panSettingCenter = 64;
            var cce = new ControlChangeEvent(0L, 1, MidiController.Pan, panSettingCenter);
            MidiOut.Send(cce.GetAsShortMessage());
        }
        public static void PlayNoteRightChannel(int key, int duration)
        {
            var panSettingHardRight = 127;
            var cce = new ControlChangeEvent(0L, 1, MidiController.Pan, panSettingHardRight);
            MidiOut.Send(cce.GetAsShortMessage());
            PlayNote(key, duration);
        }
        static void Main(string[] args)
        {
            // Plays using current setting (probably CENTER)
            Console.WriteLine( "Pan setting unchanged (should be CENTER)");
            PlayNote( 50, 2000 );
            // Set the PAN for the MIDI device to HARD LEFT...
            Console.WriteLine("Pan setting HARD LEFT");
            SetPanHardLeft();
            // ...and play the note again
            PlayNote( 50, 2000);
            // Set the PAN for the MIDI device to HARD RIGHT...
            Console.WriteLine("Pan setting HARD RIGHT");
            SetPanHardRight();
            // ...and play the note again
            PlayNote(50, 2000);
            // Set the PAN for the MIDI device back to CENTER...
            Console.WriteLine("Pan setting CENTER");
            SetPanCenter();
            // ...and play the note one last time
            PlayNote(50, 2000);
        }
    }
