       public static int GetFirstNumber(this string strInsput)
        {
            int number = 0;
            string strNumber = "";
            bool bIsContNo = true;
            bool bNoOccued = false;
            try
            {
                var arry = strInsput.ToCharArray(0, strInsput.Length - 1);
                foreach (char item in arry)
                {
                    if (char.IsNumber(item))
                    {
                        strNumber = strNumber + item.ToString();
                        bIsContNo = true;
                        bNoOccued = true;
                    }
                    else
                    {
                        bIsContNo = false;
                    }
                    if (bNoOccued && !bIsContNo)
                    {
                        break;
                    }
                }
                number = Convert.ToInt32(strNumber);
            }
            catch (Exception ex)
            {
                return 0;
            }
            return number;
        }
