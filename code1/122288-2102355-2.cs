            //Source string
            string value1 = "t";
            //Length in bits
            int length1 = 2;
            //Convert the text to an array of ASCII bytes
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(value1);
            //Create a temp BitArray from the bytes
            System.Collections.BitArray tempBits = new System.Collections.BitArray(bytes);
            //Create the output BitArray setting the maximum length
            System.Collections.BitArray bitValue1 = new System.Collections.BitArray(length1);
            //Loop through the temp array
            for(int i=0;i<tempBits.Length;i++)
            {
                //If we're outside of the range of the output array exit
                if (i >= length1) break;
                //Otherwise copy the value from the temp to the output
                bitValue1.Set(i, tempBits.Get(i));                
            }
