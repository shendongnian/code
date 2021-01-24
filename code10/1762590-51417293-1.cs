    //Cypher
    
    private byte[] Cipher(byte[] input)
    {
        byte[] buffer1 = new byte[16] { };
        try
        {
            this.State = new byte[4, this.Nb - 1 + 1];
            int num1;
            for (num1 = 0; num1 <= (4 * this.Nb) - 1; num1++)
                this.State((num1 % 4), Conversion.Int(num1 / (double)4)) = input[num1];
            this.AddRoundKey(0);
            int num2 = 1;
            while ((num2 <= (this.Nr - 1)))
            {
                this.SubBytes();
                this.ShiftRows();
                this.MixColumns();
                this.AddRoundKeys(num2);
                num2 += 1;
            }
            this.SubBytes();
            this.ShiftRows();
            this.AddRoundKey(this.Nr);
            int num3;
            for (num3 = 0; num3 <= (4 * this.Nb) - 1; num3++)
                buffer1[num3] = this.State((num3 % 4), Conversion.Int(num3 / (double)4));
        }
        catch (Exception exception)
        {
            throw;
        }
        return buffer1;
    }
