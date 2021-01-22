    using KeePassLib.Cryptography.PasswordGenerator;
    using KeePassLib.Security;
    public static string GeneratePassword(int passwordLength, bool lowerCase, bool upperCase, bool digits,
            bool punctuation, bool brackets, bool specialAscii, bool excludeLookAlike)
        {
            var ps = new ProtectedString();
            var profile = new PwProfile();
            profile.CharSet = new PwCharSet();
            profile.CharSet.Clear();
            if (lowerCase)
                profile.CharSet.AddCharSet('l');
            if(upperCase)
                profile.CharSet.AddCharSet('u');
            if(digits)
                profile.CharSet.AddCharSet('d');
            if (punctuation)
                profile.CharSet.AddCharSet('p');
            if (brackets)
                profile.CharSet.AddCharSet('b');
            if (specialAscii)
                profile.CharSet.AddCharSet('s');
            profile.ExcludeLookAlike = excludeLookAlike;
            profile.Length = (uint)passwordLength;
            profile.NoRepeatingCharacters = true;
            KeePassLib.Cryptography.PasswordGenerator.PwGenerator.Generate(out ps, profile, null, _pool);
            return ps.ReadString();
        }
