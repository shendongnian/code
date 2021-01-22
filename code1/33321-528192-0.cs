            char[] OriginalChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            char[] ScrambleChars = "9setybcpqwiuvxr108daj5'-`~!@#$%^&()+|}][{:.?/<>,;ZWQ2@#34KDART".ToCharArray();
            string TextToTransfer = "Hello";
            string NewText = "";
            foreach (char c in TextToTransfer)
            {
                NewText = NewText + ScrambleChars[Array.IndexOf<char>(OriginalChars, c)].ToString();
            }
            Console.WriteLine(NewText);
