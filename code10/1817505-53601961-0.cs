    class SoundDataBank
    {
        /**
         * Holds a single byte array for each sound
         */
        Dictionary<eSFX, Byte[]> bank;
        string curdir => Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        public SoundDataBank()
        {
            bank = new Dictionary<eSFX, byte[]>();
            bank.Add(eSFX.planet, NativeFile.ReadAllBytes(curdir + @"\Assets\Planet.wav"));
            bank.Add(eSFX.base1, NativeFile.ReadAllBytes(curdir + @"\Assets\Base.wav"));
        }
        public Byte[] GetSoundData(eSFX sfx)
        {
            byte[] output = bank[sfx];
            return output;
        }
    }
