    [WebMethod]
        public string MakeGuess(string guess)
        {
            private string code = "";
            // Pick a secret code
            // R, B, G, O, T, W, P, Y
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                int num = random.Next(8) + 1;
                if (num == 1)
                    this.code += "R";
                else if (num == 2)
                    this.code += "B";
                else if (num == 3)
                    this.code += "G";
                else if (num == 4)
                    this.code += "O";
                else if (num == 5)
                    this.code += "T";
                else if (num == 6)
                    this.code += "W";
                else if (num == 7)
                    code += "P";
                else if (num == 8)
                    this.code += "Y";
            }
            return code;
        }
