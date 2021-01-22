        /// <summary>
        /// Similar to String.GetHashCode but returns the same as the x86 version of String.GetHashCode for x64 and x86 frameworks.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static unsafe int GetHashCode32(string s)
        {
            fixed (char* str = s.ToCharArray())
            {
                char* chPtr = str;
                int num = 0x15051505;
                int num2 = num;
                int* numPtr = (int*)chPtr;
                for (int i = s.Length; i > 0; i -= 4)
                {
                    num = (((num << 5) + num) + (num >> 0x1b)) ^ numPtr[0];
                    if (i <= 2)
                    {
                        break;
                    }
                    num2 = (((num2 << 5) + num2) + (num2 >> 0x1b)) ^ numPtr[1];
                    numPtr += 2;
                }
                return (num + (num2 * 0x5d588b65));
            }
        }
