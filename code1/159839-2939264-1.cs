        private static void DoOtherThing(int[] bigArray1, int[] bigArray2)
        {
            unsafe
            {
                fixed (int* p1 = bigArray1, p2=bigArray2)
                {
                    byte* b1 = (byte*)p1;
                    byte* b2 = (byte*)p2;
                    byte* bend = (byte*)(&p1[bigArray1.Length]);
                    while (b1 < bend)
                    {
                        if (*b1 < *b2)
                        {
                            *b1 = *b2;
                        }
                        ++b1;
                        ++b2;
                    }
                }
            }
        }
