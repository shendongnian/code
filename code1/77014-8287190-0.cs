static void CheckSuffix(ref string[] sArrName)
{
// Initialize suffixes
List<string> Suffixes = new List<string>();
Suffixes.Add("jr");
Suffixes.Add("sr");
Suffixes.Add("esq");
Suffixes.Add("ii");
Suffixes.Add("iii");
Suffixes.Add("iv");
Suffixes.Add("v");
Suffixes.Add("2nd");
Suffixes.Add("3rd");
Suffixes.Add("4th");
Suffixes.Add("5th");
            int i = 0;
            string suffix = string.Empty;
            foreach (string s in sArrName)
            {
                string[] schk = s.ToLower().Split(new char[] { ' ' });
                foreach (string sverifiy in schk)
                {
                    if (Suffixes.Contains(sverifiy))
                    {
                        suffix = sverifiy;
                        sArrName[i] = sArrName[i].Replace(sverifiy.ToUpper(), string.Empty).Trim();
                    };
                }
                i += 1;
            }
            sArrName[2] = string.Format("{0}{1}", sArrName[2], (!string.IsNullOrEmpty(suffix) ? " " + suffix.ToUpper() + "." : string.Empty));
        }
        public static string[] ExtractFullname(string name)
        {
            string[] sArr = { "", "", ""};
            string[] sName = name.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            int chkinitial = -1;
            for (int i = 0; i < sName.Length; i++)
            {
                if (sName[i].Length == 1) chkinitial = i;
            }
            switch (sName.Length)
            {
                case 1:
                    sArr[0] = name;
                    break;
                case 2:
                    {
                        int idx = name.IndexOf(',');
                        if (idx != -1 && idx < name.Length) { sArr[0] = sName[1]; sArr[2] = sName[0]; } /* last, first */
                        else
                        {
                            idx = name.IndexOf(' ');
                            if (idx != -1 && idx < name.Length) { sArr[0] = sName[0]; sArr[2] = sName[1]; } /* first last */
                        }
                    }
                    break;
                case 3:
                    if (chkinitial == 1) { sArr[0] = sName[0]; sArr[1] = sName[1]; sArr[2] = sName[2]; } /* first middle last */
                    else if (chkinitial == 2) { sArr[0] = sName[1]; sArr[1] = sName[2]; sArr[2] = sName[0]; } /* last first middle */
                    else if (chkinitial == -1) {
                        int idx = name.IndexOf(',');
                        if (idx != -1)
                        {
                            if (idx == (sName[0].Length + sName[1].Length + 1))
                            {
                                sArr[0] = sName[2]; sArr[2] = string.Format("{0} {1}", sName);
                            }
                            else
                            {
                                sArr[0] = string.Format("{1} {2}", sName); sArr[2] = sName[0];
                            }
                        }
                        else
                        {
                            sArr[0] = name;
                        }
                    }
                    break;
                case 4:
                    if (chkinitial == 1) { sArr[0] = sName[0]; sArr[1] = sName[1]; sArr[2] = string.Format("{2} {3}", sName); } /* first middle last */
                    else if (chkinitial == 2) { sArr[0] = string.Format("{0} {1}", sName); sArr[1] = sName[2]; sArr[2] = sName[3]; } /* last first middle */
                    else if (chkinitial == 3) {
                        int idx = name.IndexOf(',');
                        if (idx != -1)
                        {
                            if (idx == (sName[0].Length + sName[1].Length + 1))
                            {
                                sArr[0] = sName[2]; sArr[1] = sName[3]; sArr[2] = string.Format("{0} {1}", sName);
                            }
                            else
                            {
                                sArr[0] = string.Format("{1} {2}", sName); sArr[1] = sName[3]; sArr[2] = sName[0];
                            }
                        }
                        else
                        {
                            sArr[0] = name;
                        }
                    }
                    else if (chkinitial == -1)
                    {
                        int idx = name.IndexOf(',');
                        if (idx != -1)
                        {
                            if (idx == (sName[0].Length))
                            {
                                sArr[0] = string.Format("{1} {2} {3}", sName); sArr[2] = sName[0];
                            }
                            else if (idx == (sName[0].Length + sName[1].Length + 1))
                            {
                                sArr[0] = string.Format("{2} {3}", sName); sArr[2] = string.Format("{0} {1}", sName);
                            }
                            else if (idx == (sName[0].Length + sName[1].Length + sName[2].Length + 1))
                            {
                                sArr[0] = sName[3]; sArr[2] = string.Format("{0} {1} {2}", sName);
                            }
                            else
                            {
                                sArr[0] = name;
                            }
                        }
                        else
                        {
                            sArr[0] = name;
                        }
                    }
                    break;
                default:
                    /* more than 3 item in array */
                    sArr[0] = name;
                    break;
            }
            CheckSuffix(ref sArr);
            return sArr;
        }
